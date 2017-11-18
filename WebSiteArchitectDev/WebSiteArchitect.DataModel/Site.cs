using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteArchitect.DataModel
{
    public class Site
    {
        [Key]
        public int SiteId { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }
}
