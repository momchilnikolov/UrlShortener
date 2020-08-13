using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UrlShortenerLib;
using UrlShortenerApp.Configuration;
using System.Text.RegularExpressions;

namespace UrlShortenerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        private readonly  IOptions<AppSettings> config;
        private readonly UrlShortener library;
        public ShortenUrlController(IOptions<AppSettings> config)
        {
            this.config = config;
            this.library = new UrlShortener(config.Value);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] string url)
        {
            string result = await library.Shorten(WebUtility.UrlEncode(url));

            //replace any \ chars
            Regex regex = new Regex(@"\\");
            string shortenedUrl = regex.Replace(result, "");

            //extract url from returned json string
            regex = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
            Match match = regex.Match(shortenedUrl);

            return match.Success ? match.Value : result;
        }
    }
}