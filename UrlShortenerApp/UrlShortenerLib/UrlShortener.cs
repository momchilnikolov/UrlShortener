
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UrlShortenerApp.Configuration;

namespace UrlShortenerLib
{
    public class UrlShortener
    {
        private AppSettings appSettings;
        private static HttpClient client = new HttpClient();
        public UrlShortener() { }
        public UrlShortener(AppSettings  configuration)
        {
            appSettings = configuration;
        }

        public async Task<string> Shorten(string urlToShorten)
        {
            try
            {
                //set client base address if not already set
                if (client.BaseAddress == null)
                    client.BaseAddress = new Uri(appSettings.ServiceAPIBase);
                
                //use configuration settings to build paramer list to service API
                var parameterString = string.Format("{0}={1}", appSettings.ServiceApiParamName, urlToShorten);
                var stringContent = new StringContent(parameterString, Encoding.UTF8, "application/x-www-form-urlencoded");
                //call service API asynchronously
                HttpResponseMessage response = await client.PostAsync(
                    appSettings.ServiceAPIAddress, stringContent);
                //ensure that non-success status codes throw an exception
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "There was an error shortening your url: " + ex.Message;
            }
        }
    }
}
