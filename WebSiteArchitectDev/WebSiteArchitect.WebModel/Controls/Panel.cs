using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.WebModel.Controls
{
    public class Panel : WebControl
    {
        public Panel()
        {


        }
        public Panel(string id, string name, string value, string className, List<WebControl> childrenControls) : base(id, name, WebControlType.panel, value, className)
        {
            this.ChildrenControls = childrenControls;

        }
    }
}
