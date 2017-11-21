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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebSiteArchitect.AdminApp.ViewModels;
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
            this.mainWindowVM = new MainWindowViewModel(this);
            this.DataContext = mainWindowVM;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView_SelectedItemChangedAsync(sender, e);
        }
        private async void TreeView_SelectedItemChangedAsync(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (this.WebSiteTreeView.SelectedItem != null)
            {
                var newPath = new PathHelper(this.WebSiteTreeView.SelectedItem as TreeViewItem);
                if (mainWindowVM.SelectedSite == null || mainWindowVM.SelectedSite.Name != newPath.Root)
                    mainWindowVM.SelectedSite = await mainWindowVM.Consumer.GetSiteByNameAsync(newPath.Root);

                mainWindowVM.SelectedPagePath = newPath;
            }
            else
            {
                mainWindowVM.SelectedSite = null;
                mainWindowVM.SelectedPagePath = null;
            }
        }
    }
}
