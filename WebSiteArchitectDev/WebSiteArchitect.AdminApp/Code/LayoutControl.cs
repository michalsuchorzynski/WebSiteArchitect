using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.AdminApp.Code
{
    public class LayoutControl : INotifyPropertyChanged
    {
        private UserControl _control;
        public event PropertyChangedEventHandler PropertyChanged;

        private WebControlType _controlType;
        private string _controlTypeName;
        private int _size;
        private Grid _parentControl;
        private int _childIndex;
        private string _value;

        public UserControl Control
        {
            get
            {
                return _control;
            }
            set
            {
                _control = value;
            }
        }
        public WebControlType ControlType
        {
            get
            {
                
                return _controlType;

            }
        }
        public string ControlTypeName
        {
            get
            {
                return _controlTypeName.ToLower();
            }
            set
            {
                _controlTypeName = value;
            }
        }
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                if(SetControlSize(value))
                    _size = value;
                OnPropertyChanged("Size");
            }
        }
        public Grid ParentControl
        {
            get
            {
                return _parentControl;
            }
            set
            {
                _parentControl = value;
            }
        }
        public int ChildIndex
        {
            get
            {
                return _childIndex;
            }
            set
            {
                _childIndex = value;
            }
        } 
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                switch (this.ControlType)
                {
                    case WebControlType.label:
                        (((_control.Content as Grid).Children[0] as Label).Content as AccessText).Text = value;
                        break;
                        
                }
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public LayoutControl()
        {
        }
        public LayoutControl(UserControl control):this()
        {
            this._control = control;
            ReadControlPropertFromXaml();
        }

        public bool SetControlSize(int newSize)
        {
            if (_control == null || newSize <= 0 || newSize == this.Size)
                return false;
            if (this.ControlType == WebControlType.row)
                return false;
            if (newSize > this.Size)
            {
                if (this.ChildIndex + newSize > 11)
                    return false;
                for (int i = this.ChildIndex + 1; i < this.ChildIndex + newSize; i++)
                {
                    LayoutControl child = new LayoutControl(_parentControl.Children[i] as UserControl);
                    if (child.ControlType != WebControlType.emptySpace)
                    {
                        return false;
                    }
                }
                var colDefinitions = _parentControl.ColumnDefinitions.Where(x => _parentControl.ColumnDefinitions.IndexOf(x) >= this.ChildIndex && _parentControl.ColumnDefinitions.IndexOf(x) < this.ChildIndex + newSize);
                _parentControl.ColumnDefinitions[this.ChildIndex].Width = new GridLength(newSize, GridUnitType.Star);
                for(int i = this.ChildIndex + 1; i < this.ChildIndex + newSize; i++)
                {
                    _parentControl.ColumnDefinitions[i].Width = new GridLength(0, GridUnitType.Star);
                }
            }
            else
            {
                _parentControl.ColumnDefinitions[this.ChildIndex].Width = new GridLength(newSize, GridUnitType.Star);
                for (int i = this.ChildIndex + newSize; i < this.ChildIndex + _size; i++)
                {
                    _parentControl.ColumnDefinitions[i].Width = new GridLength(1, GridUnitType.Star);
                }
            }
            //this.Size = newSize;
            return true;
        }

        


        public void ChangeControlProperty(PropertyType type, object value)
        {
            var controlToChange = (Label)(_control.Content as Grid).Children[0];
            switch (type)
            {
                case PropertyType.backgroundColor:
                    controlToChange.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(value));
                    break;
                case PropertyType.color:
                    controlToChange.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(value));
                    break;
            }
        }
        
        private void ReadControlPropertFromXaml()
        {
            switch (_control.GetType().FullName.Replace("WebSiteArchitect.AdminApp.Controls.Layout.", "").ToLower())
            {
                case "emptySpace":
                    this._controlType = WebControlType.emptySpace;
                    break;
                case "input":
                    _controlType = WebControlType.input;
                    break;
                case "label":
                    _controlType = WebControlType.label;
                    break;
                case "panel":
                    _controlType = WebControlType.panel;
                    break;
                case "select":
                    _controlType = WebControlType.select;
                    break;
                case "row":
                    _controlType = WebControlType.row;
                    break;
                default:
                    _controlType = WebControlType.emptySpace;
                    break;
            }

            _controlTypeName = _control.GetType().FullName.Replace("WebSiteArchitect.AdminApp.Controls.Layout.", "");

            _parentControl = _control.Parent as Grid;

            if (_parentControl != null)
            {
                _childIndex = _parentControl.Children.IndexOf(_control);
                _size = Convert.ToInt32(_parentControl.ColumnDefinitions[_childIndex].Width.Value);
            }
            switch (this.ControlType)
            {
                case WebControlType.label:
                    this.Value = (((_control.Content as Grid).Children[0] as Label).Content as AccessText).Text.ToString();
                    break;

            }
            

        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
