using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteArchitect.WebModel;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;
using WebSiteArchitect.WebModel.Controls;
using WebSiteArchitect.WebModel.Helpers;

namespace WebSiteArchitect.ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly string serverAddress = ServerControler.ClientWeb.Properties.Settings.Default.ServerAddress;
        private readonly string defaultPage = ServerControler.ClientWeb.Properties.Settings.Default.DefaultPage;


        public Site _currentSite;
        public Page _currentPage;
        public AdminAPIConsumer _consumer;


        #region Property
        public Site CurrrentSite
        {
            get { return _currentSite; }
            set { _currentSite = value; }
        }
        public Page CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }
        public AdminAPIConsumer Consumer
        {
            get { return _consumer; }
            set { _consumer = value; }
        }
        #endregion


        // GET: Home
        public ActionResult Index(string siteName = null, string pageName = null)
        {
            CostructSite(siteName, pageName);

            WebContent content = Settings.ConvertFromJson(_currentPage.ControlsJson);
            content.Controls = content.Controls;
            return View(content);
        }

        public void CostructSite(string siteName, string pageName)
        {
            _consumer = new AdminAPIConsumer(serverAddress);

            siteName = !string.IsNullOrEmpty(siteName) ? siteName : defaultPage; 
            _currentSite = _consumer.GetSiteByNameAsync(siteName);
            _currentSite.Pages = _consumer.GetPageForSite(_currentSite.SiteId).ToList();

            if (!string.IsNullOrEmpty(pageName))
            {
                var page = _currentSite.Pages.FirstOrDefault(p => p.Name.ToLower() == pageName.ToLower());
                if (page != null)
                    _currentPage = page;
            }
            if (_currentPage == null)
            {
                _currentPage = _currentSite.Pages.ToList()[_currentSite.StartPage];
            }
        }
    }
}