using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebSiteArchitect.AdminApp.ViewModels;
using WebSiteArchitect.DataModel;
using WebSiteArchitect.WebModel.Helpers;

namespace WebSiteArchitect.AdminApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowVM;


        public MainWindowViewModel mainWindowVM
        {
            get
            {
                return _mainWindowVM;
            }
            set
            {
                _mainWindowVM = value;
            }

        }
        public MainWindow()
        {
            InitializeComponent();
            this.mainWindowVM = new MainWindowViewModel();
            this.DataContext = mainWindowVM;
            using (var db = new DataContext())
            {
                db.SaveChanges();
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            mainWindowVM.SelectedPagePath = new PathHelper(this.WebSiteTreeView.SelectedItem as TreeViewItem);
        }
    }
}
