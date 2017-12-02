using System;
using System.Collections.Generic;
using System.Text;

namespace WebSiteArchitect.WebModel.Base
{
    public class Site
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModDate { get; set; }
        public int StartPage { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }


    }
}
