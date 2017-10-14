using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.WebModel.Controls
{
    public class Label : WebControl
    {
        public Label()
        {
            this.Type = WebControlType.label;


        }
        public Label(string id, string name, string value, string className) : base(id, name, WebControlType.label, value, className)
        { }

    }
}
