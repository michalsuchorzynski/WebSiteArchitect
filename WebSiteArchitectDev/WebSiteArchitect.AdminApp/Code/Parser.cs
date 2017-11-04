using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using WebSiteArchitect.WebModel;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Controls;

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
            var mainPanel = xamlPage.Children[0];
            ConvertToWebPage();
        }
        public WebPage ConvertToWebPage()
        {
            Page = new WebPage();
            
            foreach (UserControl childControl in XamlPage.Children)
            {
                Page.Controls.Add(GetSimpleControlFromXaml(childControl));
            }
            Settings.ConvertToJson(Page, "C:\\Users\\Michał\\Desktop\\Prac" +
                "a Inzynierska\\Test\\Json.txt");
            return Page;
        }
        public WebControl GetSimpleControlFromXaml(UserControl control)
        {
            WebControl newControl; ;
            var type = ControlHelper.GetControlType(control);
            switch (type)
            {
                case "EmptySpace":
                    newControl = new WebSiteArchitect.WebModel.Controls.EmptySpace();
                    break;
                case "Label":
                    newControl = new WebSiteArchitect.WebModel.Controls.Label();
                    newControl.Value = "text";
                    break;
                case "Panel":
                case "Row":
                    newControl = new WebSiteArchitect.WebModel.Controls.Panel();
                    foreach (UserControl childControl in ((System.Windows.Controls.Panel)control.Content).Children)
                    {
                        newControl.ChildrenControls.Add(GetSimpleControlFromXaml(childControl));
                    }
                    break;
                default:
                    return null;
            }
            ApplyClass(control, newControl, type);
            return newControl;
        }

        private void ApplyClass(UserControl control, WebControl newControl, string type)
        {
            string newClass = "";
            if (type != "Row")
            {
                var columnSize = ControlHelper.GetControlSize(control);
                if (columnSize <= 12)
                {
                    newClass += "col-md-" + columnSize.ToString() + " ";
                }
            }
            newClass += GenerateCustomClass(newControl.Type.Description());
            switch (type)
            {
                case "Row":
                    newClass = type.ToLower();
                    break;
            }
            newControl.ClassName = newClass;
            
        }

        private string GenerateCustomClass(string className)
        {
            return "wsa" + className;
        }
    }
}
