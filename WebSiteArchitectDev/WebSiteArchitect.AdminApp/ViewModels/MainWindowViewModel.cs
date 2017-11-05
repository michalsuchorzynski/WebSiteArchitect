using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebSiteArchitect.AdminApp.Commands;
using Views = WebSiteArchitect.AdminApp.Views;

namespace WebSiteArchitect.AdminApp.ViewModels
{
    public class MainWindowViewModel
    {
        private Views.Layout _layoutWindow;
        private Views.Controls _controlsWindow;

        private ICommand _newProjectCommand;
        private bool _canExecute = true;

        public Views.Layout LayoutWindow
        {
            get
            {
                return this._layoutWindow;
            }
            set
            {
                this._layoutWindow = value;
            }
        }
        public Views.Controls ControlsWindow
        {
            get
            {
                return this._controlsWindow;
            }
            set
            {
                this._controlsWindow = value;
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
        public ICommand NewProjectCommand
        {
            get
            {
                return _newProjectCommand;
            }
            set
            {
                _newProjectCommand = value;
            }
        }

        public MainWindowViewModel()
        {
            _newProjectCommand = new RelayCommand(OpenWindows, param => this._canExecute);
        }
        public void OpenWindows(object obj)
        {
            LayoutWindow = new Views.Layout(this);
            ControlsWindow = new Views.Controls(this);
            LayoutWindow.Show();
            ControlsWindow.Show();
        }
        public void ChangeCanExecute(object obj)
        {
            _canExecute = !_canExecute;
        }
    }
}
