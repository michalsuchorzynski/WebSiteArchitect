using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WebSiteArchitect.WebModel.Base;

namespace WebSiteArchitect.AdminApp.Code
{
    public class Parser
    {
        private StackPanel _xamlPage;
        private WebPage _page;
        public StackPanel XamlPage
        {
            get
            {
                return this._xamlPage;
            }
            set
            {
                _xamlPage = value;
            }
        }
        public WebPage Page
        {
            get
            {
                return this._page;
            }
            set
            {
                _page = value;
            }
        }
        public Parser(StackPanel xamlPage)
        {
            this.XamlPage = xamlPage;
        }
        public WebPage ConvertToWebPage()
        {
            Page = new WebPage();

            return Page;
        }
        public WebControl GetSimpleControlFromXaml()
        {
            WebControl control = null;
            return control;
        }

        private void SavePageToDB()
        {
            ConvertToWebPage();
        }
        private void GetPageFromDB()
        {

        }
    }
}
