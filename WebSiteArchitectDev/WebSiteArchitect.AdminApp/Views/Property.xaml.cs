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
using WebSiteArchitect.AdminApp.ViewModels;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.AdminApp.Views
{
    /// <summary>
    /// Interaction logic for Property.xaml
    /// </summary>
    public partial class Property : Window
    {
        public PropertyViewModel propertyVM;
        public Property()
        {
            InitializeComponent();
            this.combox_textAlign.ItemsSource = Enum.GetValues(typeof(TextAlignment));
        }
        public Property(MainWindowViewModel mainWindowVM) : this()
        {
            propertyVM = new PropertyViewModel(mainWindowVM);
        }

    }
}
