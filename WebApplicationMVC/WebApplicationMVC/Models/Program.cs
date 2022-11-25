namespace WebApplicationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Program
    {
        public int ProgramID { get; set; }

        public int? LeadCentreID { get; set; }

        [StringLength(50)]
        public string RemarketingValue { get; set; }

        public int CategoryID { get; set; }

        [StringLength(2)]
        public string ProvinceKey { get; set; }

        public string Name { get; set; }

        [StringLength(100)]
        public string AssociateName { get; set; }

        [StringLength(200)]
        public string FacebookForm { get; set; }

        public bool? Active { get; set; }

        public string Description { get; set; }

        public string Jobs { get; set; }

        public string Quote { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public string BrowserTitle { get; set; }

        [StringLength(100)]
        public string VideoHeader { get; set; }

        public string VideoDescription { get; set; }

        [StringLength(100)]
        public string YoutubeTag { get; set; }

        public bool ShowOnForm { get; set; }

        public string NameOnForm { get; set; }

        public string GoogleFormName { get; set; }

        public string Admissions { get; set; }

        [StringLength(100)]
        public string Duration { get; set; }

        [StringLength(100)]
        public string CertificationType { get; set; }

        public string DescriptionShort { get; set; }

        [StringLength(250)]
        public string Benefits { get; set; }

        [StringLength(30)]
        public string TestimonialName { get; set; }

        public string TestimonialQuote { get; set; }
    }
}
