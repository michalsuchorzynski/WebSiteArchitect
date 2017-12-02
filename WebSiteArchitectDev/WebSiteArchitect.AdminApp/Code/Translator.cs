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
    public class Translator
    {
        private StackPanel _xamlPage;
        private List<IWebControl> _controls;
        private LayoutControl _currentControl;
        private WebContent _content;
              

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
        public List<IWebControl> Controls
        {
            get
            {
                return this._controls;
            }
            set
            {
                _controls = value;
            }
        }
        public LayoutControl CurrentControl
        {
            get
            {
                return _currentControl;
            }
            set
            {
                _currentControl = value;
            }
        }
        public WebContent Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Translator(StackPanel xamlPage)
        {
            this.XamlPage = xamlPage;
            var mainPanel = xamlPage.Children[0];
            _controls = new List<IWebControl>();
            _content = new WebContent();

            _content.Controls = ConvertToWebPage();
        }
        public List<IWebControl> ConvertToWebPage()
        {
            
            
            foreach (UserControl childControl in XamlPage.Children)
            {
                _currentControl = new LayoutControl(childControl);
                _controls.Add(GetSimpleControlFromXaml());
            }        
            return _controls;
        }
        public WebControl GetSimpleControlFromXaml()
        {
            WebControl newControl;
            
            switch (_currentControl.ControlTypeName)
            {
                case "button":
                    newControl = new WebSiteArchitect.WebModel.Controls.Button();
                    newControl.Name = _currentControl.ControlTypeName + ControlCounter.LabelCount.ToString();
                    newControl.Value = _currentControl.Value;
                    newControl.GoTo = _currentControl.GoTo;
                    break;
                case "emptyspace":
                    newControl = new WebSiteArchitect.WebModel.Controls.EmptySpace();
                    break;
                case "label":
                    newControl = new WebSiteArchitect.WebModel.Controls.Label();
                    newControl.Name = _currentControl.ControlTypeName + ControlCounter.LabelCount.ToString();
                    newControl.Value = _currentControl.Value;
                    break;
                case "panel":
                case "row":
                    newControl = new WebSiteArchitect.WebModel.Controls.Panel();
                    foreach (UserControl childControl in ((System.Windows.Controls.Panel)_currentControl.Control.Content).Children)
                    {
                        var tempCurrentControl = _currentControl;
                        _currentControl = new LayoutControl(childControl);
                        newControl.ChildrenControls.Add(GetSimpleControlFromXaml());
                        _currentControl = tempCurrentControl;
                    }
                    break;
                case "input":
                    newControl = new WebSiteArchitect.WebModel.Controls.Input();
                    newControl.Name = _currentControl.ControlTypeName + ControlCounter.InputCount.ToString();
                    newControl.Value = _currentControl.Value;

                    break;
                case "select":
                    newControl = new WebSiteArchitect.WebModel.Controls.Select();
                    newControl.Name = _currentControl.ControlTypeName + ControlCounter.SelectCount.ToString();
                    newControl.Value = _currentControl.Value;
                    break;
                default:
                    return null;
            }
            ApplyClass(newControl);
            return newControl;
        }

        private void ApplyClass(WebControl newControl)
        {
            string newClass = "";
            if (_currentControl.ControlTypeName != "row")
            {
                var columnSize = _currentControl.Size;
                if (columnSize <= 12)
                {
                    newClass += "col-md-" + columnSize.ToString() + " ";
                }
            }
            newClass += GenerateCustomClass(newControl.Type.Description());
            switch (_currentControl.ControlTypeName)
            {
                case "row":
                    newClass = _currentControl.ControlTypeName;
                    break;
                case "button":
                    newClass += " btn btn-default";
                    break;
            }
            newControl.ClassName = newClass;
            
        }

        private string GenerateCustomClass(string className)
        {
            className = className[0].ToString().ToUpper() + className.Substring(1);
            return "wsa" + className;
        }
    }
}
