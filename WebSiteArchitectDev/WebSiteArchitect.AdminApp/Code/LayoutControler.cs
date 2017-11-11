using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WebSiteArchitect.AdminApp.Controls.Layout;
using WebSiteArchitect.WebModel;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Controls;

namespace WebSiteArchitect.AdminApp.Code
{
    public class LayoutControler
    {
        private LayoutControl _selectedControl;
        private StackPanel _xamlPage;
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
        
        public LayoutControler(StackPanel xamlPage)
        {
            this.XamlPage = xamlPage;
        }

        public void AddRowToPage()
        {
            AddRowToPanel(XamlPage);            
        }
        public void DeleteRowFromPage(Row selected)
        {
            DeleteControl(selected);
        }
        private void AddRowToPanel(StackPanel panel)
        {
            if (panel != null)
            {
                panel.Children.Add(new Row());
            }
        }

        public void AddControl(UserControl toAdd, UserControl todelete)
        {
            var parent = todelete.Parent as Grid;
            var controlIndexOf = parent.Children.IndexOf(todelete);
            parent.Children.Remove(todelete);
            parent.Children.Insert(controlIndexOf,toAdd);
            Grid.SetColumn(toAdd, controlIndexOf);
        }

        public bool DeleteControl(UserControl notSelected = null)
        {
            if (notSelected != null)
                _selectedControl = new LayoutControl(notSelected);
            switch (_selectedControl.ControlTypeName)
            {
                case "EmptySpace":
                    return false;
                case "Row":
                    foreach(UserControl childControl in ((System.Windows.Controls.Panel)_selectedControl.Control.Content).Children)
                    {
                        if (_selectedControl.ControlTypeName != "EmptySpace")
                        {
                            return false;
                        }
                    }
                    break;
                case "Panel":
                    break;
            }
            _selectedControl.SetControlSize(1);
            AddControl(new Controls.Layout.EmptySpace(), _selectedControl.Control);
            return true;
        }

        public void MoveControl(UserControl oldPosition, UserControl newPosition)
        {
            AddControl(newPosition, oldPosition);
            DeleteControl(oldPosition);
        }
    }
}
