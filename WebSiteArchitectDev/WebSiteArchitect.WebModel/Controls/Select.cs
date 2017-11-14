﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteArchitect.WebModel.Base;
using WebSiteArchitect.WebModel.Enums;

namespace WebSiteArchitect.WebModel.Controls
{
    public class Select : WebControl
    {
        public Select()
        {
            this.Type = WebControlTypeEnum.select;


        }
        public Select(string id, string name, string value, string className) : base(id, name, WebControlTypeEnum.select, value, className)
        { }

    }
}
