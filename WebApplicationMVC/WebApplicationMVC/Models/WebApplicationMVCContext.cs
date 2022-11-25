using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplicationMVC.Models
{
    public partial class WebApplicationMVCContext : DbContext
    {
        public WebApplicationMVCContext()
            : base("name=WebApplicationMVCContext")
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
