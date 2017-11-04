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
using System.Windows.Shapes;
using WebSiteArchitect.AdminApp.Code;
using WebSiteArchitect.AdminApp.ViewModels;

namespace WebSiteArchitect.AdminApp.Views
{
    /// <summary>
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : Window
    {
        public Layout()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StackPanel Page = (StackPanel)this.FindName("PageLayout");
            Parser parser = new Parser(Page);
        }

        private void PageLayout_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel Page = (StackPanel)this.FindName("PageLayout");
            LayoutControler controler = new LayoutControler(Page);
            controler.AddRowToPage();
        }
    }
}
