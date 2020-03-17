using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogApi.Data
{
    // DbContext provides instruction to entity framework core 
    // when it is about to set the DB
    public class CatalogContext : DbContext
    {
        // DB context information, dependency injection
        public CatalogContext(DbContextOptions options) : base(options)
        {}

        // create a table called CatalogBrands which is type of DbSet<CatalogBrand>
        // CatalogBrands is the internal reference
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }

        // when its about to create the table override this method and
        // modelBuilder will build the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>(e =>
            {
                // set up table's name
                e.ToTable("CatalogBrands");
                // set up table's columns
                e.Property(b => b.Id)
                    .IsRequired()
                    // Hilo : high and low means DB will give you a range we can choose any ids in the range
                    // constraint
                    .UseHiLo("catalog_brand_hilo");

                e.Property(b => b.Brand)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CatalogType>(e =>
            {
                e.ToTable("CatalogTypes");
                e.Property(t => t.Id)
                    .IsRequired()
                    .UseHiLo("catalog_type_hilo");

                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CatalogItem>(e =>
            {
                e.ToTable("Catalog");
                e.Property(c => c.Id)
                    .IsRequired()
                    .UseHiLo("catalo_hilo");

                e.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(c => c.Price)
                    .IsRequired();

                // 1 : many relationship with foreignkey CatalogTypeId
                e.HasOne(c => c.CatalogType)
                    .WithMany()
                    .HasForeignKey(c => c.CatalogTypeId);

                e.HasOne(c => c.CatalogBrand)
                 .WithMany()
                 .HasForeignKey(c => c.CatalogBrandId);
            });


        }
    }
}
