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

        public string GenerateCSS(LayoutControl control, WebControl newControl, string siteName)
        {
            string cssClass = "";
            siteName = "." + siteName;
            if (!string.IsNullOrEmpty(control.FontColor.ToString()) || !string.IsNullOrEmpty(control.BackgroundColor.ToString()))
            {
                cssClass = siteName + " " + newControl.Name + "Custom";
                _styles += siteName + " ." + newControl.Name + "Custom,\n";
                _styles += siteName + " ." + newControl.Name + "Custom input,\n";
                _styles += siteName + " ." + newControl.Name + "Custom select,\n";
                _styles += siteName + " ." + newControl.Name + "Custom label,\n";
                _styles += siteName + " ." + newControl.Name + "Custom a,\n";
                _styles += siteName + " ." + newControl.Name + "Custom span{\n";


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
            if (control.ControlType == WebModel.Enums.WebControlTypeEnum.button || control.ControlType == WebModel.Enums.WebControlTypeEnum.input)
            {
                if (control.ControlType == WebModel.Enums.WebControlTypeEnum.button)
                {
                    _styles += siteName + " ." + newControl.Name + "Custom a{\n";
                }
                else if (control.ControlType == WebModel.Enums.WebControlTypeEnum.input)
                {
                    _styles += siteName + " ." + newControl.Name + "Custom input{\n";
                }
                _styles += "background-color:" + "rgb(" + control.ContentColor.Value.R + "," + control.ContentColor.Value.G + "," + control.ContentColor.Value.B + ");\n";
                _styles += "border-color:" + "rgb(" + control.ContentColor.Value.R + "," + control.ContentColor.Value.G + "," + control.ContentColor.Value.B + ");\n";
                _styles += "}\n";
            }

            return cssClass;
        }

        public void SaveFile(string siteName = null)
        {
            var result = "";
            using (StreamReader sr = new StreamReader(_path))
            {
                result = sr.ReadToEnd();
            }
            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.WriteLine(result + _styles + (siteName != null ? "/*End " + siteName + "*/" : ""));
            }

        }
        public void ClearFile(string siteName)
        {
            var styles = ""; 
            using (StreamReader sr = new StreamReader(_path))
            {
                styles = sr.ReadToEnd();
            }
            var startIndex = styles.IndexOf("/*Start "+siteName +"*/");
            var endIndex = styles.IndexOf("/*End " + siteName + "*/") + 9 + siteName.Length;
            var result = "";
            if (startIndex > -1 && endIndex > -1) 
                result = styles.Substring(0, startIndex) + styles.Substring(endIndex+1) + "/*Start " + siteName + "*/";
            else
                result = styles  +"/*Start " + siteName + "*/"; ;

            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.WriteLine(result);
            }
        }
    }
}
