namespace WebApplicationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Campuses")]
    public partial class Campus
    {
        [Key]
        public int EFID { get; set; }

        public int? CampusID { get; set; }

        public bool Active { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(2)]
        public string ProvinceKey { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Description { get; set; }

        public string Directions { get; set; }

        public string Address { get; set; }

        public string Map { get; set; }

        public string MapUrl { get; set; }

        public string GoogleMapUrl { get; set; }

        public string ThingsToDo { get; set; }

        public string PlacesToVolunteer { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public string BrowserTitle { get; set; }

        public int PermissionID { get; set; }

        public string NewsletterDescription { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public string DescriptionShort { get; set; }

        public string ImageCampus { get; set; }
    }
}
