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

        private WebControlTypeEnum _controlType;
        private string _controlTypeName;
        private int _size;
        private object _content;
        private Grid _parentControl;
        private int _childIndex;
        private string _value;
        private Color? _backgroundColor;
        private Color? _fontColor;
        private TextAlignment _textAlign;
        private string _goTo;

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
        public WebControlTypeEnum ControlType
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
        public object Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
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
                    case WebControlTypeEnum.button:
                        (_content as Button).Content = value;
                        break;
                    case WebControlTypeEnum.emptySpace:
                        break;
                    case WebControlTypeEnum.input:
                        (_content as TextBox).Text = value;
                        break;
                    case WebControlTypeEnum.label:
                        (_content as AccessText).Text = value;
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
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        public Color? BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                var converter = new System.Windows.Media.BrushConverter();
                switch (this.ControlType)
                {
                    case WebControlTypeEnum.button:
                        (_content as Button).Background = (Brush)converter.ConvertFromString(value.ToString());
                        break;
                    case WebControlTypeEnum.emptySpace:
                        break;
                    case WebControlTypeEnum.input:
                        (_content as TextBox).Background = (Brush)converter.ConvertFromString(value.ToString());
                        break;
                    case WebControlTypeEnum.label:
                        (_control.Content as Grid).Background = (Brush)converter.ConvertFromString(value.ToString());
                        break;
                    case WebControlTypeEnum.panel:
                        break;
                    case WebControlTypeEnum.select:
                        (_content as ComboBox).Background = (Brush)converter.ConvertFromString(value.ToString());
                        break;
                    case WebControlTypeEnum.row:
                        break;
                    default:
                        break;
                }
                _backgroundColor = value;
                OnPropertyChanged("BackgroundColor");
            }
        }
        public Color? FontColor
        {
            get
            {
                return _fontColor;
            }
            set
            {
                var converter = new System.Windows.Media.BrushConverter();
                switch (this.ControlType)
                {
                    case WebControlTypeEnum.button:
                        (_content as Button).Foreground = (Brush)converter.ConvertFromString(value.ToString());
                        break;
                    case WebControlTypeEnum.emptySpace:
                        break;
                    case WebControlTypeEnum.input:
                        (_content as TextBox).Foreground = (Brush)converter.ConvertFromString(value.ToString());
                        break;
                    case WebControlTypeEnum.label:
                        (_content as AccessText).Foreground = (Brush)converter.ConvertFromString(value.ToString());
                        break;
                    case WebControlTypeEnum.panel:
                        break;
                    case WebControlTypeEnum.select:
                        (_content as ComboBox).Foreground = (Brush)converter.ConvertFromString(value.ToString());
                        break;
                    case WebControlTypeEnum.row:
                        break;
                    default:
                        break;
                }
                _fontColor = value;
                OnPropertyChanged("FontColor");
            }
        }
        public TextAlignment TextAlign
        {
            get
            {
                return _textAlign;
            }
            set
            {
                switch (this.ControlType)
                {

                    case WebControlTypeEnum.input:
                        (_content as TextBox).TextAlignment = value;
                        break;
                    case WebControlTypeEnum.label:
                        (_content as AccessText).TextAlignment = value;
                        break;
                }
                _textAlign = value;
                OnPropertyChanged("TextAlign");
            }
        }
        public string GoTo
        {
            get
            {
                return _goTo;
            }
            set
            {
                
                switch (this.ControlType)
                {
                    case WebControlTypeEnum.button:
                        (_content as Button).Name = value;
                        break;
                       
                }
                _goTo = value;
                OnPropertyChanged("GoTo");
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
            if (this.ControlType == WebControlTypeEnum.row)
                return false;
            if (newSize > this.Size)
            {
                if (this.ChildIndex + newSize > 11)
                    return false;
                for (int i = this.ChildIndex + 1; i < this.ChildIndex + newSize; i++)
                {
                    LayoutControl child = new LayoutControl(_parentControl.Children[i] as UserControl);
                    if (child.ControlType != WebControlTypeEnum.emptySpace)
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
            return true;
        }      
                      
        private void ReadControlPropertFromXaml()
        {
            SolidColorBrush newBrush;
            switch (_control.GetType().FullName.Replace("WebSiteArchitect.AdminApp.Controls.Layout.", "").ToLower())
            {
                case "button":
                    _controlType = WebControlTypeEnum.button;
                    _content = ((_control.Content as Grid).Children[0] as Button);
                    newBrush = (SolidColorBrush)((_content as Button).Background);
                    _backgroundColor = newBrush.Color;
                    newBrush = (SolidColorBrush)((_content as Button).Foreground);
                    _fontColor = newBrush.Color;
                    _goTo = (_content as Button).Name;
                    this.Value = (_content as Button).Content.ToString();
                    break;
                case "emptySpace":
                    this._controlType = WebControlTypeEnum.emptySpace;
                    _controlType = WebControlTypeEnum.label;
                    _content = ((_control.Content as Grid).Children[0] as Label).Content;                    
                    break;
                case "input":
                    _controlType = WebControlTypeEnum.input;
                    _content = ((_control.Content as Grid).Children[0] as TextBox);
                    newBrush = (SolidColorBrush)((_content as TextBox).Background);
                    _backgroundColor = newBrush.Color;
                    newBrush = (SolidColorBrush)((_content as TextBox).Foreground);
                    _fontColor = newBrush.Color;
                    this.Value = (_content as TextBox).Text.ToString();
                    _textAlign = (_content as TextBox).TextAlignment;
                    break;
                case "label":
                    _controlType = WebControlTypeEnum.label;
                    _content = ((_control.Content as Grid).Children[0] as Label).Content;
                    newBrush = (SolidColorBrush)((_control.Content as Grid).Background);
                    _backgroundColor = newBrush.Color;
                    newBrush = (SolidColorBrush)((_content as AccessText).Foreground);
                    _fontColor = newBrush.Color;
                    this.Value = (_content as AccessText).Text.ToString();
                    _textAlign = (_content as AccessText).TextAlignment;
                    break;
                case "panel":
                    _controlType = WebControlTypeEnum.panel;                    
                    break;
                case "select":
                    _controlType = WebControlTypeEnum.select;
                    _content = ((_control.Content as Grid).Children[0] as ComboBox);
                    newBrush = (SolidColorBrush)((_content as ComboBox).Background);
                    _backgroundColor = newBrush.Color;
                    newBrush = (SolidColorBrush)((_content as ComboBox).Foreground);
                    _fontColor = newBrush.Color;
                    break;
                case "row":
                    _controlType = WebControlTypeEnum.row;
                    break;
                default:
                    _controlType = WebControlTypeEnum.emptySpace;
                    break;
            }

            _controlTypeName = _control.GetType().FullName.Replace("WebSiteArchitect.AdminApp.Controls.Layout.", "");

            _parentControl = _control.Parent as Grid;

            if (_parentControl != null)
            {
                _childIndex = _parentControl.Children.IndexOf(_control);
                _size = Convert.ToInt32(_parentControl.ColumnDefinitions[_childIndex].Width.Value);
            }           
            

        }

        public event PropertyChangedEventHandler PropertyChanged;
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
