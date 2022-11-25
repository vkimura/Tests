namespace WebApplicationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Page
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Page()
        {
            Variables = new HashSet<Variable>();
        }

        public int PageID { get; set; }

        public int ParentID { get; set; }

        public int? ContentTypeID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime PublishDate { get; set; }

        [StringLength(150)]
        public string Url { get; set; }

        [Required]
        [StringLength(200)]
        public string Caption { get; set; }

        [StringLength(200)]
        public string Segment { get; set; }

        [StringLength(6)]
        public string Extension { get; set; }

        public int Order { get; set; }

        public bool Default { get; set; }

        public bool Active { get; set; }

        public int Status { get; set; }

        public int TemplateID { get; set; }

        public bool ShowInSiteMap { get; set; }

        public bool ShowInSiteNav { get; set; }

        public string Notes { get; set; }

        public bool NewWindow { get; set; }

        public int TemplateRoot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Variable> Variables { get; set; }
    }
}
