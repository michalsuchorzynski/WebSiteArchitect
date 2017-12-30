using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.WebModel.Controls
{
    public class Image : WebControl
    {
        public Image()
        {
            this.Type = WebControlTypeEnum.image;


        }
        public Image(string id, string name, string value, string className) : base(id, name, WebControlTypeEnum.image, value, className)
        { }

    }
}
