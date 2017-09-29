using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.WebModel.Base
{
    public interface IWebControl
    {
        string Id { get; set; }
        string Name { get; set; }
        WebControlType Type { get; set; }
        string Value { get; set; }
        string ClassName { get; set; }
        List<WebControl> ChildrenControls { get; set; }
        
    }
}
