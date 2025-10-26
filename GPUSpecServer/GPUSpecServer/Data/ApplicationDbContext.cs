using GPUSpecServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GPUSpecServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }
        public ApplicationDbContext(DbContextOptions options)

         : base(options)
        {
        }

        public DbSet<Architecture> Architectures { get; set; }
        public DbSet<Chip> Chips { get; set; }
        public DbSet<Generation> Generations { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<GenerationArchitecture> GenerationArchitectures { get; set; }
        public DbSet<ProductChip> ProductChips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder = builder.AddJsonFile("appsettings.json");
            builder = builder.AddJsonFile("appsettings.Development.json", true);
            builder = builder.AddUserSecrets<ApplicationDbContext>(true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
