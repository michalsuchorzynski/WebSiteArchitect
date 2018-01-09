using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WebSiteArchitect.AdminApp.Code;
using WebSiteArchitect.AdminApp.Commands;
using WebSiteArchitect.AdminApp.Views;
using WebSiteArchitect.WebModel;
using Base = WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Helpers;

namespace WebSiteArchitect.AdminApp.ViewModels
{
    public class MainWindowViewModel
    {
        
        private AdminAPIConsumer _consumer;

        private MainWindow _mainWindow;
        private Views.Layout _layoutWindow;
        private Views.Controls _controlsWindow;
        private Views.Property _propertyWindow;

        private IEnumerable<Base.Site> _sites;
        private IEnumerable<Base.Menu> _menus;
        private IEnumerable<Base.Page> _pages;

        private ICommand _newProjectCommand;
        private ICommand _newPageCommand;
        private ICommand _newMenuCommand;
        private ICommand _deleteCommand;
        private bool _canExecute = true;

        private PathHelper _selectedPagePath;
        private Base.Site _selectedSite;
        private Base.Page _selectedPage;
        private Base.Menu _selectedMenu;

        #region Property
        public AdminAPIConsumer Consumer
        {
            get
            {
                return _consumer;
            }
            set
            {
                _consumer = value;
            }
        }
        public Views.Layout LayoutWindow
        {
            get
            {
                return this._layoutWindow;
            }
            set
            {
                this._layoutWindow = value;
            }
        }
        public Views.Controls ControlsWindow
        {
            get
            {
                return this._controlsWindow;
            }
            set
            {
                this._controlsWindow = value;
            }
        }
        public Views.Property PropertWindow
        {
            get
            {
                return _propertyWindow;
            }
            set
            {
                _propertyWindow = value;
            }
        }
        public IEnumerable<Base.Page> PageSites
        {
            get
            {
                return _pages;
            }
            set
            {
                value = _pages;
            }
        }

        public bool CanExecute
        {
            get
            {
                return this._canExecute;
            }

            set
            {
                if (this._canExecute == value)
                {
                    return;
                }

                this._canExecute = value;
            }
        }
        public ICommand NewProjectCommand
        {
            get
            {
                return _newProjectCommand;
            }
            set
            {
                _newProjectCommand = value;
            }
        }
        public ICommand NewPageCommand
        {
            get
            {
                return _newPageCommand;
            }
            set
            {
                _newPageCommand = value;
            }
        }
        public ICommand NewMenuCommand
        {
            get
            {
                return _newMenuCommand;
            }
            set
            {
                _newMenuCommand = value;
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand;
            }
            set
            {
                _deleteCommand = value;
            }
        }

        public PathHelper SelectedPagePath
        {
            get
            {
                return _selectedPagePath;
            }
            set
            {
                _selectedPagePath = value;
            }
        }
        public Base.Site SelectedSite
        {
            get
            {
                return _selectedSite;
            }
            set
            {
                _selectedSite = value;
            }
        }
        public Base.Page SelectedPage
        {
            get
            {
                return _selectedPage;
            }
            set
            {
                _selectedPage = value;
            }
        }
        public Base.Menu SelectedMenu
        {
            get
            {
                return _selectedMenu;
            }
            set
            {
                _selectedMenu = value;
            }
        }
        
        #endregion
        public MainWindowViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _consumer = new AdminAPIConsumer(Properties.Settings.Default.ServerAddress);
            _newProjectCommand = new RelayCommand(AddNewProjectAsync);
            _newPageCommand = new RelayCommand(AddNewPage);
            _newMenuCommand = new RelayCommand(AddNewMenu);
            _deleteCommand = new RelayCommand(DeleteAsync);
            ConstructTreeView();
        }

        public void  AddNewProjectAsync(object obj)
        {
            Base.Site newSite = new Base.Site();
            AddWindow add = new AddWindow(newSite, Consumer,this);
            add.Show();           
        }
        public void AddNewPage(object obj)
        {
            Base.Page newPage = new Base.Page();
            LayoutWindow = new Views.Layout(this);            
            newPage.SiteId = SelectedSite.SiteId;
            newPage.XamlPageString = Settings.XamlToSring((StackPanel)LayoutWindow.FindName("PageLayout"));
            AddWindow add = new AddWindow(newPage, Consumer, this);
            add.Show();
        }
        public void AddNewMenu(object obj)
        {
            Base.Menu newMenu = new Base.Menu();
            LayoutWindow = new Views.Layout(this);
            newMenu.SiteId = SelectedSite.SiteId;
            newMenu.XamlPageString = Settings.XamlToSring((StackPanel)LayoutWindow.FindName("PageLayout"));
            AddWindow add = new AddWindow(newMenu, Consumer,this);
            add.Show();
        }
        public async void DeleteAsync(object obj)
        {
            if (SelectedSite != null)
            {
                if (SelectedMenu != null)
                {
                    await _consumer.DeleteAsync("api/menu", SelectedMenu.MenuId);
                }
                else if (SelectedPage != null)
                {
                    await _consumer.DeleteAsync("api/page", SelectedPage.PageId);
                }
                else
                {
                    await _consumer.DeleteAsync("api/site", SelectedSite.SiteId);
                }
            }
            _mainWindow.mainWindowVM.ConstructTreeView();
        }

        public void OpenWindows()
        {
            if (LayoutWindow != null)
                LayoutWindow.Close();
            LayoutWindow = new Views.Layout(this);

            this._layoutWindow.layoutVM.Controler.XamlPage = (StackPanel)this.LayoutWindow.FindName("PageLayout");

            if (SelectedPage != null)
            {
                this._layoutWindow.layoutVM.Controler.XamlPage = Settings.StringToXaml(this.SelectedPage.XamlPageString);
            }
            else if(SelectedMenu!=null)
            {
                this._layoutWindow.layoutVM.Controler.XamlPage = Settings.StringToXaml(this.SelectedMenu.XamlPageString);
            }
            (this._layoutWindow.FindName("PageLayoutParent") as Grid).Children.Clear();
            (this._layoutWindow.FindName("PageLayoutParent") as Grid).Children.Add(this._layoutWindow.layoutVM.Controler.XamlPage);

            ControlsWindow = new Views.Controls(this);
            PropertWindow = new Views.Property(this);
            if (!LayoutWindow.IsVisible)
            {
                LayoutWindow.Show();                
            }
            ControlsWindow.Hide();
            PropertWindow.Hide();
            if (LayoutWindow.IsVisible)
            {
                LayoutWindow.Activate();
            }
        }

        public void ConstructTreeView()
        {
            this._mainWindow.WebSiteTreeView.Items.Clear();
           
            _sites = _consumer.GetSites("api/site", null);
            _menus = _consumer.GetMenu("api/menu", null);
            _pages = _consumer.GetPages("api/page", null);
            foreach (var site in _sites)
            {
                if (!string.IsNullOrEmpty(site.Name))
                {
                    var siteItem = new TreeViewItem()
                    {
                        Header = site.Name
                    };
                    var siteMenus = _menus.Where(x => x.SiteId == site.SiteId);
                    foreach (var menu in siteMenus)
                    {
                        siteItem.Items.Add(new TreeViewItem()
                        {
                            Header = menu.Name
                        });
                    }
                    var pageFolder = new TreeViewItem()
                    {
                        Header = "Pages"
                    };
                    var sitePages = _pages.Where(x => x.SiteId == site.SiteId);
                    foreach (var page in sitePages)
                    {
                        pageFolder.Items.Add(new TreeViewItem()
                        {
                            Header = page.Name
                        });
                    }
                    siteItem.Items.Add(pageFolder);
                    this._mainWindow.WebSiteTreeView.Items.Add(siteItem);
                    SelectedPagePath = null;
                }
            }
        }

        public void ChangeCanExecute(object obj)
        {
            _canExecute = !_canExecute;
        }        
    }
}
