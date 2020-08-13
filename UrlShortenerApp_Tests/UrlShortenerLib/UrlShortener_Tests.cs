using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlShortenerLib;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortenerApp.Configuration;

namespace UrlShortenerLib.Tests
{
    [TestClass()]
    public class UrlShortener_Tests
    {
        [TestMethod()]
        public async void Shorten_Test()
        {
            var appSettings = new AppSettings {
                ServiceAPIBase = "https://cleanuri.com",
                ServiceAPIAddress = "api/v1/shorten",
                ServiceApiParamName = "url"
            };
            UrlShortener urlShortener = new UrlShortener(appSettings);


            string result = await urlShortener.Shorten("http://google.com");

            // Assert
            StringAssert.Contains(result, "https://cleanuri.com");
            

        }
    }
}