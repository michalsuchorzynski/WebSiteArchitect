﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebSiteArchitect.WebModel.Base;

namespace WebSiteArchitect.AdminAPI.Model
{
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PageId { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModDate { get; set; }

        [Column("XamlPage")]
        public string XamlPageString { get; set; }

        [Column("Controls")]
        public string ControlsJson { get; set; }
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
              

    }
}
