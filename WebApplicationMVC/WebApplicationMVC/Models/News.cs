namespace WebApplicationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public int NewsID { get; set; }

        public bool? Active { get; set; }

        [StringLength(2)]
        public string ProvinceKey { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? PublishDate { get; set; }
    }
}
