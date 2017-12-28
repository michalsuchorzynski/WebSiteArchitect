using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.AdminApp.Code;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.AdminApp.ViewModels
{
    public class PropertyViewModel
    {
        private LayoutControl _selectedControl;
        private MainWindowViewModel _mainWindowVM;

        public LayoutControl SelectedControl
        {
            get
            {
                return _selectedControl;
            }
            set
            {
                _selectedControl = value;
                switch (_selectedControl.ControlType)
                {
                    case WebControlTypeEnum.button:
                        _mainWindowVM.PropertWindow.labelGoto.Visibility =System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtGoto.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.labelContentColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtContentColor.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case WebControlTypeEnum.emptySpace:
                        break;
                    case WebControlTypeEnum.input:
                        break;
                    case WebControlTypeEnum.label:
                        break;
                    case WebControlTypeEnum.panel:
                        break;
                    case WebControlTypeEnum.select:
                        break;
                    case WebControlTypeEnum.row:
                        break;
                    default:
                        break;
                }
                _mainWindowVM.PropertWindow.DataContext = _selectedControl;
            }
        }


        public PropertyViewModel(MainWindowViewModel mainWindowVM)
        {
            _mainWindowVM = mainWindowVM;
            if (SelectedControl!=null)
                mainWindowVM.PropertWindow.DataContext = SelectedControl;
         
        }

    
    }
}
