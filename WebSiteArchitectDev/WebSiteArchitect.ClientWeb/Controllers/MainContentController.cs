using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;

namespace ServerControler.ClientWeb.Controllers
{
    public class MainContentController : Controller
    {
        // GET: MainContent
        public ActionResult Index()
        {
            return View();
        }
    }
}