using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteArchitect.WebModel;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;
using WebSiteArchitect.WebModel.Controls;

namespace WebSiteArchitect.ClientWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            #region Test1

            //WebControl controlEmptySpace = new WebControl(WebControlType.emptySpace);
            //WebControl controlInput = new Input("testInput","testInput","testInput","TestInput");
            //WebControl controlLabel = new Label("testLabel", "testLabel", "testLabel", "testLabel");
            //WebControl controlSelect = new Select("testSelect", "testSelect", "testSelect", "testSelect");
            //WebControl controlPanel = new Panel("testPanel", "testPanel", "testPanel", "testPanel",null);
            //WebControl controlInput2 = new Input("testInput2", "testInput2", "testInput2", "TestInput2");
            //WebControl controlLabel2 = new Label("testLabel2", "testLabel2", "testLabel2", "testLabel2");
            //WebControl controlSelect2 = new Select("testSelect2", "testSelect2", "testSelect2", "testSelect2");
            //List<WebControl> elementsInPanel = new List<WebControl>();
            //elementsInPanel.Add(controlInput2);
            //elementsInPanel.Add(controlLabel2);
            //elementsInPanel.Add(controlSelect2);
            //WebControl controlPanel2 = new Panel("testPanel", "testPanel", "testPanel", "testPanel", elementsInPanel);
            //WebPage page = new WebPage();
            //page.Controls.Add(controlEmptySpace);
            //page.Controls.Add(controlInput);
            //page.Controls.Add(controlLabel);
            //page.Controls.Add(controlSelect);
            //page.Controls.Add(controlPanel);
            //page.Controls.Add(controlPanel2);
#endregion

            WebPage page = Settings.ConvertFromJson("C:\\Users\\Michał\\Desktop\\Praca Inzynierska\\Test\\Json.txt");

            return View(page);
        }
    }
}