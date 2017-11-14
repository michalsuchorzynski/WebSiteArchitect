using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.WebModel.Controls
{
    public class EmptySpace : WebControl
    {
        public EmptySpace()
        {
            this.Type = WebControlTypeEnum.emptySpace;

        }
        public EmptySpace(string id, string name, string value, string className) : base(id, name, WebControlTypeEnum.emptySpace, value, className)
        { }    
        
    }
}
