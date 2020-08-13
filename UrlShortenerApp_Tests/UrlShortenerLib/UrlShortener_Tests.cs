using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlShortenerLib;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortenerApp.Configuration;
using System.Threading.Tasks;

namespace UrlShortenerLib.Tests
{
    [TestClass()]
    public class UrlShortenerTests
    {
        [TestMethod()]
        public async Task ShortenTest()
        {
            //TO DO: Get configuration from appsettings.json
            var appSettings = new AppSettings {
                ServiceAPIBase = "https://cleanuri.com",
                ServiceAPIAddress = "api/v1/shorten",
                ServiceApiParamName = "url"
            };
      
            UrlShortener urlShortener = new UrlShortener(appSettings);


            string result = await urlShortener.Shorten("http://google.com");

            // Assert
            StringAssert.Contains(result, "cleanuri.com");
        }
    }
}