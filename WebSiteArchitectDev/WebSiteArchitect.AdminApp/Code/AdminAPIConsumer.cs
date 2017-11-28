using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebSiteArchitect.AdminApp.Code
{
    public class AdminAPIConsumer
    {
        private string _serverAddress = Properties.Settings.Default.ServerAddress;
        private HttpClient client;
        public string Error { get; set; }

        public AdminAPIConsumer()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(_serverAddress);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<bool> AddAsync(string request, object param)
        {
            var response = await client.PostAsJsonAsync(request, param);
            if (response.IsSuccessStatusCode)
            {
                this.Error = string.Empty;
                return true;

            }
            else
            {
                this.Error = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
                return false;
            }
        }
        public async Task<bool> UpdateAsync(string request, object param)
        {            
            var response = await client.PutAsJsonAsync(request, param);
            if (response.IsSuccessStatusCode)
            {
                this.Error = string.Empty;
                return true;

            }
            else
            {
                this.Error = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
                return false;
            }
        }
        public async Task<bool> DeleteAsync(string request, long id)
        {
            var response = await client.DeleteAsync(request +"/" + id);
            if (response.IsSuccessStatusCode)
            {
                this.Error = string.Empty;
                return true;

            }
            else
            {
                this.Error = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
                return false;
            }
        }

        public IEnumerable<Site> GetSites(string request, object param)
        {
            HttpResponseMessage response = client.GetAsync("api/site").Result;
            var sites = response.Content.ReadAsAsync<IEnumerable<Site>>().Result;
            if (response.IsSuccessStatusCode)
            {
                this.Error = string.Empty;
                return sites;

            }
            else
            {
                this.Error = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
                return null;
            }
        }
        public async Task<Site> GetSiteByNameAsync(string name)
        {
            HttpResponseMessage response = await client.GetAsync("/api/site/byname/" + name);
            var site = await response.Content.ReadAsAsync<Site>();
            if (response.IsSuccessStatusCode)
            {
                this.Error = string.Empty;
                return site;

            }
            else
            {
                this.Error = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
                return null;
            }
        }
        public IEnumerable<Menu> GetMenu(string request, object param)
        {
            HttpResponseMessage response = client.GetAsync("api/menu").Result;
            var menus = response.Content.ReadAsAsync<IEnumerable<Menu>>().Result;
            if (response.IsSuccessStatusCode)
            {
                this.Error = string.Empty;
                return menus;

            }
            else
            {
                this.Error = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
                return null;
            }
        }

        public IEnumerable<Menu> GetMenuByName(string name, Site selectedSite)
        {
            HttpResponseMessage response = client.GetAsync("api/menu/byname/" + name).Result;
            var menus = response.Content.ReadAsAsync<IEnumerable<Menu>>().Result;
            menus = menus.Where(m=>m.SiteId==selectedSite.SiteId);
            if (response.IsSuccessStatusCode)
            {
                this.Error = string.Empty;
                return menus;

            }
            else
            {
                this.Error = "Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase;
                return null;
            }
        }

        public IEnumerable<Page> GetPages(string request, object param)
        {
            HttpResponseMessage response = client.GetAsync("api/page").Result;
            var pages = response.Content.ReadAsAsync<IEnumerable<Page>>().Result;
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

        public IEnumerable<Page> GetPageByName(string name, Site selectedSite)
        {
            HttpResponseMessage response = client.GetAsync("api/page/byname/" + name).Result;
            var pages = response.Content.ReadAsAsync<IEnumerable<Page>>().Result;
            pages = pages.Where(p => p.SiteId == selectedSite.SiteId);
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
