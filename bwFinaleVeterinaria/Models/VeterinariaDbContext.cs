using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace bwFinaleVeterinaria.Models
{
    public partial class VeterinariaDbContext : DbContext
    {
        public VeterinariaDbContext()
            : base("name=VeterinariaDbContext")
        {
        }

        public virtual DbSet<Cabinet> Cabinets { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Drawer> Drawers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RescueAdmission> RescueAdmissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Drawer>()
                .HasMany(e => e.Cabinets)
                .WithRequired(e => e.Drawer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Owner>()
                .Property(e => e.FiscalCode)
                .IsFixedLength();

            modelBuilder.Entity<Owner>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Owner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pet>()
                .Property(e => e.Microchip)
                .IsUnicode(false);

            modelBuilder.Entity<Pet>()
                .HasMany(e => e.Examinations)
                .WithRequired(e => e.Pet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pet>()
                .HasMany(e => e.RescueAdmissions)
                .WithRequired(e => e.Pet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Cabinets)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RescueAdmission>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
