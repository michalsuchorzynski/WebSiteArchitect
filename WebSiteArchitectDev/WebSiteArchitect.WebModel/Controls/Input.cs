using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.WebModel.Controls
{
    public class Input : WebControl
    {
        public Input()
        {
            this.Type = WebControlType.input;


        }
        public Input(string id, string name, string value, string className) : base(id, name, WebControlType.input, value, className)
        { }

    }
}
