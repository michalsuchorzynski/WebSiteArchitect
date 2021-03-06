﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebSiteArchitect.WebModel.Base
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModDate { get; set; }
        public string XamlPageString { get; set; }
        public string ControlsJson { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

    }
}
