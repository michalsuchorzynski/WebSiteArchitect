using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WebSiteArchitect.AdminApp.Commands;
using System.Threading.Tasks;
using WebSiteArchitect.AdminApp.Controls;
using System.Windows.Controls;
using System.Windows.Media;

namespace WebSiteArchitect.AdminApp.ViewModels
{
    
    public class ControlsViewModel
    {
        private Button _selectedButton;
        private ICommand _selectButtonCommand;
        private bool _canExecute = true;

        public Button SelectedButton
        {
            get
            {
                return _selectedButton;
            }
            set
            {
                _selectedButton = value;
            }
        }
        public bool CanExecute
        {
            get
            {
                return this._canExecute;
            }

            set
            {
                if (this._canExecute == value)
                {
                    return;
                }

                this._canExecute = value;
            }
        }
        public ICommand SelectButtonCommand
        {
            get
            {
                return _selectButtonCommand;
            }
            set
            {
                _selectButtonCommand = value;
            }
        }


        public ControlsViewModel(MainWindowViewModel mainWindowVM)
        {
            _selectButtonCommand = new RelayCommand(SelectButton, param => this._canExecute);
        }
        public void SelectButton(object obj)
        {
            _selectedButton = (Button)obj;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(VisualTreeHelper.GetParent(_selectedButton)); i++)
            {
                var btn = (Button)VisualTreeHelper.GetChild(VisualTreeHelper.GetParent(_selectedButton), i);
                if (btn != _selectedButton)
                {
                    btn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
                }
                else
                {
                    btn.Background = Brushes.Gold;
                }
            }
        }
        public void ChangeCanExecute(object obj)
        {
            _canExecute = !_canExecute;
        }
    }
}
