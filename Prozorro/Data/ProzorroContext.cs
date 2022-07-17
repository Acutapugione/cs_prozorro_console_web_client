using Prozorro.Models;
using Prozorro.Models.Internals;
using Microsoft.EntityFrameworkCore;

namespace Prozorro.Data
{
    public class ProzorroContext : DbContext
    {
        private string DbPath;

        public ProzorroContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "prozorro.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<CategoryDTO>? CategoryDTOs { get; set; }

        public DbSet<OfferDTO>? OfferDTOs { get; set; }

        public DbSet<ProductDTO>? ProductDTOs { get; set; }

        public DbSet<ProfileDTO>? ProfileDTOs { get; set; }

        public DbSet<VendorDTO>? VendorDTOs { get; set; }

        public DbSet<Classification>? Classifications { get; set; }

        public DbSet<Identifier>? Identifiers { get; set; }

        
    }
}
