using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DXWebApplication1.Models.DbAp
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<service>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<service>()
                .HasMany(e => e.services1)
                .WithOptional(e => e.service1)
                .HasForeignKey(e => e.ParentKey);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.bio)
                .IsUnicode(false);
        }
    }
}
