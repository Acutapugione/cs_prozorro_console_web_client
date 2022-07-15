using Microsoft.EntityFrameworkCore;
using Prozorro.Models;
using Prozorro.Models.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prozorro.Data
{
    public class ProzorroContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
            }
        }

        public DbSet<CategoryDTO> Categories { get; set; }

        public DbSet<OfferDTO> Offers { get; set; }

        public DbSet<ProductDTO> Products { get; set; }

        public DbSet<ProfileDTO> Profiles { get; set; }

        public DbSet<VendorDTO> Vendors { get; set; }
        
    }
}
