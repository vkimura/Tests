using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplicationMVC.Models
{
    public partial class CDICollegeContext : DbContext
    {
        public CDICollegeContext()
            : base("name=CDICollegeContext")
        {
        }

        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Variable> Variables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
