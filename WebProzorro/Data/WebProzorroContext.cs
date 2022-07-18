using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProzorro.Models;
using WebProzorro.Models.Internals;

namespace WebProzorro.Data
{
    public class WebProzorroContext : DbContext
    {
        public WebProzorroContext (DbContextOptions<WebProzorroContext> options)
            : base(options)
        {
            
        }

        public DbSet<CategoryDTO> CategoryDTOs { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProcuringEntity> ProcuringEntities { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<ContactPoint> ContactPoints { get; set; }
        public DbSet<Identifier> Identifiers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<OfferDTO>? OfferDTOs { get; set; }
        public DbSet<Value>? Values { get; set; }
        public DbSet<MinOrderValue>? MinOrderValues { get; set; }

        public DbSet<ProductDTO>? ProductDTOs { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<RequirementResponse>? RequirementResponses { get; set; }

        public DbSet<ProfileDTO>? ProfileDTOs { get; set; }
        public DbSet<Сriterion>? Сriterions { get; set; }
        public DbSet<RequirementGroup>? RequirementGroups { get; set; }
        public DbSet<Requirement>? Requirements { get; set; }
        public DbSet<Unit>? Units { get; set; }

        public DbSet<VendorDTO>? VendorDTOs { get; set; }
        public DbSet<Vendor>? Vendors { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Document>? Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasOne<VendorDTO>()
                .WithMany(x => x.Categories);

            builder.Entity<Document>()
                .HasOne<VendorDTO>()
                .WithMany(x => x.Documents);
            
            builder.Entity<Supplier>()
                .HasOne<Identifier>()
                .WithMany(x => x.Suppliers);

            base.OnModelCreating(builder);
        }
    }
}
