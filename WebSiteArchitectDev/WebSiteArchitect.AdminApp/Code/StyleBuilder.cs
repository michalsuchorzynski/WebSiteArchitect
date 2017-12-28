using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WebSiteArchitect.WebModel.Base;

namespace WebSiteArchitect.AdminApp.Code
{
    public class StyleBuilder
    {
        private string _styles;
        private string _path;


        public string Styles
        {
            get { return _styles; }
            set { _styles = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }


        public StyleBuilder(string directory)
        {
            _path = directory + "\\Layout.css";
        }

        public string GenerateCSS(LayoutControl control, WebControl newControl)
        {
            string cssClass = "";
            if (!string.IsNullOrEmpty(control.FontColor.ToString()) || !string.IsNullOrEmpty(control.BackgroundColor.ToString()))
            {
                cssClass = " " + newControl.Name + "Custom";
                _styles += " ." + newControl.Name + "Custom,\n";
                _styles += "." + newControl.Name + "Custom input,\n";
                _styles += "." + newControl.Name + "Custom select,\n";
                _styles += "." + newControl.Name + "Custom label,\n";
                _styles += "." + newControl.Name + "Custom a,\n";
                _styles += "." + newControl.Name + "Custom span{\n";


                if (!string.IsNullOrEmpty(control.FontColor.ToString()))
                {
                    _styles += "color:" + "rgb(" + control.FontColor.Value.R + "," + control.FontColor.Value.G + "," + control.FontColor.Value.B + ");\n";
                }
                if (!string.IsNullOrEmpty(control.BackgroundColor.ToString()))
                {
                    _styles += "background-color:" + "rgb(" + control.BackgroundColor.Value.R + "," + control.BackgroundColor.Value.G + "," + control.BackgroundColor.Value.B + ");\n";
                }
                if (!string.IsNullOrEmpty(control.FontSize.ToString()) && control.FontSize != 0)
                {
                    _styles += "font-size:" + control.FontSize + "px;\n";
                }

                _styles += "}\n";
            }
            if (control.ControlType == WebModel.Enums.WebControlTypeEnum.button)
            {
                _styles += "." + newControl.Name + "Custom a{\n";
                _styles += "background-color:" + "rgb(" + control.ContentColor.Value.R + "," + control.ContentColor.Value.G + "," + control.ContentColor.Value.B + ");\n";
                _styles += "border-color:" + "rgb(" + control.ContentColor.Value.R + "," + control.ContentColor.Value.G + "," + control.ContentColor.Value.B + ");\n";
                _styles += "}\n";
            }

                return cssClass;
        }

        public void SaveFile()
        {
            var result = "";
            using (StreamReader sr = new StreamReader(_path))
            {
                result = sr.ReadToEnd();
            }
            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.WriteLine(result + _styles);
            }

        }
        public void ClearFile()
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.WriteLine("");
            }
        }
    }
}
