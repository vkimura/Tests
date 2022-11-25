namespace WebApplicationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public int CategoryID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string RemarketingValue { get; set; }

        [StringLength(50)]
        public string Caption { get; set; }

        public string DescriptionShort { get; set; }

        [StringLength(160)]
        public string BrowserTitle { get; set; }
    }
}
