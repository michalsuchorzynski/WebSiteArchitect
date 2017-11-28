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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private AdminAPIConsumer consumer;
        private MainWindowViewModel mainWindowVM;
        private int type;
        private Site site;
        private Page page;
        private Menu menu; 
        public AddWindow(AdminAPIConsumer consumer, MainWindowViewModel mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
            this.consumer = consumer;
            InitializeComponent();
        }
        public AddWindow(Site site, AdminAPIConsumer consumer, MainWindowViewModel mainWindowVM) :this(consumer,mainWindowVM)
        {
            this.site = site;
            this.type = 0;
            InitializeComponent();
        }
        public AddWindow(Page page, AdminAPIConsumer consumer, MainWindowViewModel mainWindowVM) : this(consumer,mainWindowVM)
        {
            this.page = page;
            this.type = 1;
            InitializeComponent();
        }
        public AddWindow(Menu menu, AdminAPIConsumer consumer, MainWindowViewModel mainWindowVM) : this(consumer, mainWindowVM)
        {
            this.menu = menu;
            this.type = 2;
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            switch (type)
            {
                case 0:
                    {
                        this.site.Name = this.Name.Text;
                        this.site.CreateDate = DateTime.Now;
                        this.site.ModDate = DateTime.Now;
                        await consumer.AddAsync("api/site", site);

                        break;
                    }
                case 1:
                    {
                        this.page.Name = this.Name.Text;
                        this.page.CreateDate = DateTime.Now;
                        this.page.ModDate = DateTime.Now;
                        await consumer.AddAsync("api/page", page);

                        break;
                    }
                case 2:
                    {
                        this.menu.Name = this.Name.Text;
                        this.menu.CreateDate = DateTime.Now;
                        this.menu.ModDate = DateTime.Now;
                        await consumer.AddAsync("api/menu", menu);

                        break;
                    }                
            }
            this.mainWindowVM.ConstructTreeView();
            this.Close();
        }
    }
}
