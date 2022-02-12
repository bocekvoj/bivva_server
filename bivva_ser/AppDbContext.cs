using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace bivva_ser
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<courses> courses { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<courses>()
                .Property(e => e.course_name)
                .IsUnicode(false);

            modelBuilder.Entity<courses>()
                .Property(e => e.course_description)
                .IsUnicode(false);

            modelBuilder.Entity<courses>()
                .HasMany(e => e.users1)
                .WithMany(e => e.courses1)
                .Map(m => m.ToTable("course_instances", "bivaa").MapLeftKey("course_id").MapRightKey("user_id"));

            modelBuilder.Entity<roles>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<roles>()
                .HasMany(e => e.users)
                .WithRequired(e => e.roles)
                .HasForeignKey(e => e.user_role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.user_password)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.courses)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.tutor_id)
                .WillCascadeOnDelete(false);
        }
    }
}
