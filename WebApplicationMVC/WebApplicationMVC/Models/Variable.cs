namespace WebApplicationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Variable
    {
        public int VariableID { get; set; }

        public int PageID { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(150)]
        public string Caption { get; set; }

        public string Value { get; set; }

        public int? MaxCharCount { get; set; }

        public virtual Page Page { get; set; }
    }
}
