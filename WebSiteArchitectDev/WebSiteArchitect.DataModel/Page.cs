using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteArchitect.DataModel
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }

        public Site Site { get; set; }
    }
}
