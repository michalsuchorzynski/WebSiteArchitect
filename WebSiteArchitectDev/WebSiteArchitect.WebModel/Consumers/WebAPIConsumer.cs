using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebSiteArchitect.WebModel.Consumers
{
    public class WebAPIConsumer
    {
        private string _serverAddress = "http://localhost:49461";
        private HttpClient client;
        public string Error { get; set; }

        public WebAPIConsumer()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(_serverAddress);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string GetPageContent(string request, int id)
        {
            HttpResponseMessage response = client.GetAsync("api/page/content/" + id).Result;
            var pages = response.Content.ReadAsAsync<string>().Result;
            if (response.IsSuccessStatusCode)
            {
                this.Error = string.Empty;
                return pages;

            }
            else
            {
                this.Error = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
                return null;
            }
        }
    }
}
