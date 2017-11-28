using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteArchitect.WebModel;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;
using WebSiteArchitect.WebModel.Controls;
using WebSiteArchitect.WebModel.Consumers;

namespace WebSiteArchitect.ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            
            WebAPIConsumer consumer = new WebAPIConsumer();
            string contentControl = consumer.GetPageContent("", 1018);
            WebContent content = Settings.ConvertFromJson(contentControl);
            content.Controls = content.Controls;
            return View(content);
        }
    }
}