using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WebSiteArchitect.AdminApp.Controls.Layout;
using WebSiteArchitect.AdminApp.ViewModels;
using WebSiteArchitect.WebModel;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Controls;
using WebSiteArchitect.WebModel.Helpers;

namespace WebSiteArchitect.AdminApp.Code
{
    public class LayoutControler : INotifyPropertyChanged
    {
        private MainWindowViewModel _mainWindowVM;
        private LayoutControl _selectedControl;
        private StackPanel _xamlPage;
        private int _editMode;

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
        public int EditMode
        {
            get
            {
                return _editMode;
            }
            set
            {
                _editMode = value;
                OnEditModeChangeAsync();
                OnPropertyChanged("EditMode");
            }
        }

        public LayoutControler(StackPanel xamlPage,MainWindowViewModel mainWindowVM)
        {
            this.XamlPage = xamlPage;
            
            if (mainWindowVM.SelectedPage != null)
            {
                
                this.XamlPage = Settings.StringToXaml(mainWindowVM.SelectedPage.XamlPageString);
            }
            this._mainWindowVM = mainWindowVM;
            this.EditMode = -1;
        }

        public async void OnEditModeChangeAsync()
        {
            switch (_editMode)
            {
                case -1:
                    if (_mainWindowVM.ControlsWindow != null)
                        _mainWindowVM.ControlsWindow.Hide();
                    if (_mainWindowVM.PropertWindow != null)
                        _mainWindowVM.PropertWindow.Hide();
                    break;
                case 0:
                    _mainWindowVM.ControlsWindow.Show();
                    _mainWindowVM.PropertWindow.Hide();
                    break;
                case 1:
                    _mainWindowVM.ControlsWindow.Hide();
                    _mainWindowVM.PropertWindow.Hide();
                    break;
                case 2:
                    _mainWindowVM.ControlsWindow.Hide();
                    _mainWindowVM.PropertWindow.Hide();
                    AddRowToPage();
                    break;
                case 3:
                    _mainWindowVM.ControlsWindow.Hide();
                    _mainWindowVM.PropertWindow.Hide();
                    break;
                case 4:
                    _mainWindowVM.ControlsWindow.Hide();
                    _mainWindowVM.PropertWindow.Show();
                    break;
                case 5:
                    _mainWindowVM.ControlsWindow.Hide();
                    _mainWindowVM.PropertWindow.Hide();

                    _mainWindowVM.SelectedPage.XamlPageString = Settings.XamlToSring(this.XamlPage);
                    Translator translator = new Translator(this.XamlPage);
                    _mainWindowVM.SelectedPage.ControlsJson = Settings.ConvertToJson(translator.Content);

                    UpdatePageRequest req = new UpdatePageRequest()
                    {
                        Id = _mainWindowVM.SelectedPage.PageId,
                        XamlSchema = _mainWindowVM.SelectedPage.XamlPageString,
                        Controls = _mainWindowVM.SelectedPage.ControlsJson
                    };
                    _mainWindowVM.Consumer.UpdateAsync("api/page", req);
                    break;
            }
        }

        public void AddRowToPage()
        {
            AddRowToPanel(this.XamlPage);            
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
