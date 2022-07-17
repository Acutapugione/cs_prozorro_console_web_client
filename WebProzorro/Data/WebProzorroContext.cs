using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prozorro.Models;
using Prozorro.Models.Internals;

namespace WebProzorro.Data
{
    public class WebProzorroContext : DbContext
    {
        public WebProzorroContext (DbContextOptions<WebProzorroContext> options)
            : base(options)
        {
            
        }

        public DbSet<Prozorro.Models.CategoryDTO>? CategoryDTOs { get; set; }

        public DbSet<Prozorro.Models.OfferDTO>? OfferDTOs { get; set; }

        public DbSet<Prozorro.Models.ProductDTO>? ProductDTOs { get; set; }

        public DbSet<Prozorro.Models.ProfileDTO>? ProfileDTOs { get; set; }

        public DbSet<Prozorro.Models.VendorDTO>? VendorDTOs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryDTO>().ToTable(nameof(CategoryDTOs));
            builder.Entity<OfferDTO>().ToTable(nameof(OfferDTOs));
            builder.Entity<ProductDTO>().ToTable(nameof(ProductDTOs));
            builder.Entity<ProfileDTO>().ToTable(nameof(ProfileDTOs));
            builder.Entity<VendorDTO>().ToTable(nameof(VendorDTOs));

            base.OnModelCreating(builder);
        }
    }
}
