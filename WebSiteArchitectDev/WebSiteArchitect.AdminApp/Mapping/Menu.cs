using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebSiteArchitect.AdminApp
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModDate { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

    }
}
