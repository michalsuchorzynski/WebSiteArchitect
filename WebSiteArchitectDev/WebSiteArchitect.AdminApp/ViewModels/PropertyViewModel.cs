using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.AdminApp.Code;

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
