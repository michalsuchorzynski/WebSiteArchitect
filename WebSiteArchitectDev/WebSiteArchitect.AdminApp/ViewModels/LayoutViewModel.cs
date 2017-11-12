using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WebSiteArchitect.AdminApp.Code;
using WebSiteArchitect.WebModel.Enums;
using LayoutControls = WebSiteArchitect.AdminApp.Controls.Layout;

namespace WebSiteArchitect.AdminApp.ViewModels
{
    public class LayoutViewModel
    {
        private LayoutControler _controler;
        private MainWindowViewModel _mainWindowVM;

        public LayoutControler Controler
        {
            get
            {
                return _controler;
            }
            set
            {
                _controler = value;
            }
        }

        public LayoutViewModel(MainWindowViewModel mainWindowVM, StackPanel page)
        {
            _mainWindowVM = mainWindowVM;
            _controler = new LayoutControler(page, mainWindowVM);
        }

        public void LayoutControl_MouseLeftButtonDown(object sender)
        {
            switch (_controler.EditMode)
            {
                case 0:
                    AddControl(sender);
                    break;
                case 1:
                    DeleteControl(sender);
                    break;
                case 4:
                    _mainWindowVM.PropertWindow.propertyVM.SelectedControl = new LayoutControl(sender as UserControl);
                    break;
            }
        }

        public void AddControl(object sender)
        {
            if(_mainWindowVM.ControlsWindow.controlVM.SelectedButton == null)
            {
                return;
            }
            object controlToAdd = new LayoutControls.EmptySpace();
            string typeOfNewControl = _mainWindowVM.ControlsWindow.controlVM.SelectedButton.Content.ToString();
            switch (typeOfNewControl)
            {
                case "Input":
                    controlToAdd = new LayoutControls.Input();
                    break;
                case "Label":
                    controlToAdd = new LayoutControls.Label();
                    break;
                case "Panel":
                    controlToAdd = new LayoutControls.Panel();
                    break;
                case "Select":
                    controlToAdd = new LayoutControls.Select();
                    break;
                default:
                    controlToAdd = new LayoutControls.EmptySpace();
                    break;
            }
            _controler.AddControl(controlToAdd as UserControl, sender as UserControl);
        }
        public void DeleteControl(object sender)
        {
            _controler.DeleteControl(sender as UserControl);
        }
    }
}
