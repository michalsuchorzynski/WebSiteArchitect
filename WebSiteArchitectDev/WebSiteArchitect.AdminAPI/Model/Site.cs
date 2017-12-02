using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebSiteArchitect.AdminAPI.Model
{
    public class Site
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SiteId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModDate { get; set; }
        public int StartPage { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
