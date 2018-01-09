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
                        _mainWindowVM.PropertWindow.labelBackColor.Visibility =System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.colorBackColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelContentColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtContentColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelFontColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.colorFontColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelFontSize.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtFontSize.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelGoto.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtGoto.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtGoto.ItemsSource = _mainWindowVM.PageSites.Select(s => s.Name).ToList();

                        _mainWindowVM.PropertWindow.labelHeight.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtHeight.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelTextAlign.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.comboxTextAlign.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelItemAlign.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.comboItemAlign.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelVerticalAlign.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.comboVerticalAlign.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelValue.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtValue.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelWidth.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtWidth.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case WebControlTypeEnum.emptySpace:
                        _mainWindowVM.PropertWindow.labelBackColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.colorBackColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelContentColor.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtContentColor.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelFontColor.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.colorFontColor.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelFontSize.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtFontSize.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelGoto.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtGoto.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelHeight.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtHeight.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelTextAlign.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.comboxTextAlign.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelItemAlign.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.comboItemAlign.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelVerticalAlign.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.comboVerticalAlign.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelValue.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtValue.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelWidth.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtWidth.Visibility = System.Windows.Visibility.Visible;

                        break;
                    case WebControlTypeEnum.input:
                        _mainWindowVM.PropertWindow.labelBackColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.colorBackColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelContentColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtContentColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelFontColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.colorFontColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelFontSize.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtFontSize.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelGoto.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtGoto.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelHeight.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtHeight.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelTextAlign.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.comboxTextAlign.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelItemAlign.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.comboItemAlign.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelVerticalAlign.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.comboVerticalAlign.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelValue.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtValue.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelWidth.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtWidth.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case WebControlTypeEnum.label:
                        _mainWindowVM.PropertWindow.labelBackColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.colorBackColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelContentColor.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtContentColor.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelFontColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.colorFontColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelFontSize.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtFontSize.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelGoto.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtGoto.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelHeight.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtHeight.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelTextAlign.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.comboxTextAlign.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelItemAlign.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.comboItemAlign.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelVerticalAlign.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.comboVerticalAlign.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelValue.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtValue.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelWidth.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtWidth.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case WebControlTypeEnum.image:
                        _mainWindowVM.PropertWindow.labelBackColor.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.colorBackColor.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelContentColor.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtContentColor.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelFontColor.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.colorFontColor.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelFontSize.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtFontSize.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelGoto.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtGoto.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelHeight.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.txtHeight.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelTextAlign.Visibility = System.Windows.Visibility.Hidden;
                        _mainWindowVM.PropertWindow.comboxTextAlign.Visibility = System.Windows.Visibility.Hidden;

                        _mainWindowVM.PropertWindow.labelItemAlign.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.comboItemAlign.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelVerticalAlign.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.comboVerticalAlign.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelValue.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtValue.Visibility = System.Windows.Visibility.Visible;

                        _mainWindowVM.PropertWindow.labelWidth.Visibility = System.Windows.Visibility.Visible;
                        _mainWindowVM.PropertWindow.txtWidth.Visibility = System.Windows.Visibility.Visible;
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
