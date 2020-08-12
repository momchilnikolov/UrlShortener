using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortenerLib;

namespace UrlShortenerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        [HttpPost]
        public async Task<string> Post([FromBody] string url)
        {

            var result = await UrlShortener.Shorten(WebUtility.UrlEncode(url));
            return string.Format("result: '{0}'", result);
        }
    }
}