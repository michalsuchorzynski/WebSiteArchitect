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

namespace WebSiteArchitect.AdminApp.Controls.Layout
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : UserControl
    {
        public Image()
        {
            InitializeComponent();
        }
        private void LayoutControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void LayoutControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Views.Layout layoutView = (Views.Layout)Window.GetWindow(this);
            layoutView.layoutVM.LayoutControl_MouseLeftButtonDown(sender);

        }
    }
}
