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
using Base = WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Controls;
using WebSiteArchitect.WebModel.Helpers;
using System.Threading;

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
            if (_mainWindowVM.ControlsWindow == null)
            {
                _mainWindowVM.ControlsWindow = new Views.Controls();
            }
            if (_mainWindowVM.PropertWindow == null)
            {
                _mainWindowVM.PropertWindow = new Views.Property();
            }

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
                    break;
                case 3:
                    _mainWindowVM.ControlsWindow.Hide();
                    _mainWindowVM.PropertWindow.Hide();
                    break;
                case 4:
                    _mainWindowVM.ControlsWindow.Hide();
                    _mainWindowVM.PropertWindow.Hide();
                    break;
                case 5:
                    _mainWindowVM.ControlsWindow.Hide();
                    _mainWindowVM.PropertWindow.Show();
                    break;
                case 6:
                    _mainWindowVM.ControlsWindow.Hide();
                    _mainWindowVM.PropertWindow.Hide();

                    StyleBuilder _styleBuilder = new StyleBuilder("C:\\Users\\Michał\\Desktop\\Praca Inzynierska\\WebSiteArchitect\\WebSiteArchitectDev\\WebSiteArchitect.ClientWeb\\Content\\Style");
                    _styleBuilder.ClearFile();

                    if (_mainWindowVM.SelectedPage != null)
                    {
                        _mainWindowVM.SelectedPage.XamlPageString = Settings.XamlToSring(this.XamlPage);
                        UpdatePageRequest req = new UpdatePageRequest()
                        {
                            Id = _mainWindowVM.SelectedPage.PageId,
                            XamlSchema = _mainWindowVM.SelectedPage.XamlPageString,
                            Controls = null
                        };
                        _mainWindowVM.Consumer.UpdateAsync("api/page", req);
                    }
                    else if (_mainWindowVM.SelectedMenu != null)
                    {
                        _mainWindowVM.SelectedMenu.XamlPageString = Settings.XamlToSring(this.XamlPage);

                        UpdatePageRequest req = new UpdatePageRequest()
                        {
                            Id = _mainWindowVM.SelectedMenu.MenuId,
                            XamlSchema = _mainWindowVM.SelectedMenu.XamlPageString,
                            Controls = null
                        };
                        _mainWindowVM.Consumer.UpdateAsync("api/menu", req);
                    }

                    Thread.Sleep(1000);
                    if (_mainWindowVM.SelectedSite != null)
                    {
                        var pages = _mainWindowVM.Consumer.GetPageForSite(_mainWindowVM.SelectedSite.SiteId).ToList();
                        var menus = _mainWindowVM.Consumer.GetMenusForSite(_mainWindowVM.SelectedSite.SiteId).ToList();
                        ControlCounter.Clear();

                        foreach (Base.Page page in pages)
                        {
                            Translator translator = new Translator(Settings.StringToXaml(page.XamlPageString));
                            UpdatePageRequest req = new UpdatePageRequest()
                            {
                                Id = page.PageId,
                                XamlSchema = page.XamlPageString,
                                Controls = Settings.ConvertToJson(translator.Content)
                            };
                            _mainWindowVM.Consumer.UpdateAsync("api/page", req);
                        }

                        foreach (Base.Menu menu in menus)
                        {
                            Translator translator = new Translator(Settings.StringToXaml(menu.XamlPageString));
                            UpdatePageRequest req = new UpdatePageRequest()
                            {
                                Id = menu.MenuId,
                                XamlSchema = menu.XamlPageString,
                                Controls = Settings.ConvertToJson(translator.Content)
                            };
                            _mainWindowVM.Consumer.UpdateAsync("api/menu", req);
                        }

                        ControlCounter.Clear();

                    }

                    break;
            }
        }

        public void AddRowToPage(Row selected)
        {
            var parent = (selected.Parent) as StackPanel;
            var controlIndexOf = parent.Children.IndexOf(selected);
            parent.Children.Insert(controlIndexOf + 1, new Row());
        }
        public void DeleteRowFromPage(Row selected)
        {
            var parent = (selected.Parent) as StackPanel;
            if (parent.Children.Count > 1)
            {
                var controlIndexOf = parent.Children.IndexOf(selected);
                parent.Children.Remove(selected);
            }

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

        public void MoveControl(UserControl newPosition, UserControl oldPosition)
        {
            var parent = newPosition.Parent as Grid;
            var controlIndexOf = parent.Children.IndexOf(newPosition);
            parent.Children.Remove(newPosition);
            DeleteControl(oldPosition);
            parent.Children.Insert(controlIndexOf, oldPosition);
            Grid.SetColumn(oldPosition, controlIndexOf);
            
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
