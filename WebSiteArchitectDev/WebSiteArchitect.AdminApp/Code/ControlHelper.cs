using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WebSiteArchitect.AdminApp.Code
{
    public static class ControlHelper
    {
        public static string GetControlType(UserControl control)
        {
            return control.GetType().FullName.Replace("WebSiteArchitect.AdminApp.Controls.Layout.", "");
        }
        public static bool SetControlSize(UserControl control, int newSize)
        {
            var prevSize = GetControlSize(control);
            if (control == null || newSize <= 0 || newSize == prevSize)
                return false;
            if (GetControlType(control) == "Row")
                return false;
            var parentCtrl = control.Parent as Grid;
            var ctrlindex = parentCtrl.Children.IndexOf(control);
            if (newSize > prevSize)
            {
                if (ctrlindex + newSize > 11)
                    return false;
                for (int i = ctrlindex + 1; i < ctrlindex + newSize; i++)
                {
                    if (GetControlType(parentCtrl.Children[i] as UserControl) != "EmptySpace")
                    {
                        return false;
                    }
                }
                var colDefinitions = parentCtrl.ColumnDefinitions.Where(x => parentCtrl.ColumnDefinitions.IndexOf(x) >= ctrlindex && parentCtrl.ColumnDefinitions.IndexOf(x) < ctrlindex + newSize);
                parentCtrl.ColumnDefinitions[ctrlindex].Width = new GridLength(newSize, GridUnitType.Star);
                for(int i = ctrlindex + 1; i < ctrlindex + newSize; i++)
                {
                    parentCtrl.ColumnDefinitions[i].Width = new GridLength(0, GridUnitType.Star);
                }
            }
            else
            {
                parentCtrl.ColumnDefinitions[ctrlindex].Width = new GridLength(newSize, GridUnitType.Star);
                for (int i = ctrlindex + newSize; i < ctrlindex + prevSize; i++)
                {
                    parentCtrl.ColumnDefinitions[i].Width = new GridLength(1, GridUnitType.Star);
                }
            }

            return true;
        }
        public static int GetControlSize(UserControl control)
        {
            if (control == null)
            {
                return 0;
            }
            var parentCtrl = control.Parent as Grid;
            var ctrlindex = parentCtrl.Children.IndexOf(control);
            return Convert.ToInt32(parentCtrl.ColumnDefinitions[ctrlindex].Width.Value);
        }
    }
}
