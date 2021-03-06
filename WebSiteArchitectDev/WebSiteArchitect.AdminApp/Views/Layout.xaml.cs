﻿using System;
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
        public LayoutViewModel layoutVM;
        public MainWindowViewModel mainWindowVM;

        public Layout()
        {
            InitializeComponent();
        }
        public Layout(MainWindowViewModel mainWindowVM):this()
        {
            StackPanel page = (StackPanel)this.FindName("PageLayout");
            layoutVM = new LayoutViewModel(mainWindowVM, page);
            this.mainWindowVM = mainWindowVM;
            this.DataContext = layoutVM.Controler;
        }

        private void Layout_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.mainWindowVM.PropertWindow.propertyVM.SelectedControl != null)
            {
                if (e.Key == Key.NumPad4)
                {
                    this.mainWindowVM.PropertWindow.propertyVM.SelectedControl.Size = this.mainWindowVM.PropertWindow.propertyVM.SelectedControl.Size - 1;
                }
                else if (e.Key == Key.NumPad6)
                {
                    this.mainWindowVM.PropertWindow.propertyVM.SelectedControl.Size = this.mainWindowVM.PropertWindow.propertyVM.SelectedControl.Size + 1;
                }
            }
            if (e.Key == Key.D)
            {

            }
        }
    }
}
