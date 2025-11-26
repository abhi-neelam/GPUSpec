using CsvHelper;
using GPUSpecServer.Data.Models;
using GPUSpecServer.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace GPUSpecServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        IHostEnvironment environment;
        public ApplicationDbContext(IHostEnvironment environment) : base()
        {
            this.environment = environment;
        }

        public ApplicationDbContext(DbContextOptions options, IHostEnvironment environment)

         : base(options)
        {
            this.environment = environment;
        }

        public DbSet<Chip> Chips { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Listing> Listings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder = builder.AddJsonFile("appsettings.json");
            builder = builder.AddJsonFile("appsettings.Development.json", true);
            builder = builder.AddUserSecrets<ApplicationDbContext>(true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .UseSeeding((context, _) =>
            {
                var chips = context.Set<Chip>().ToDictionary(c => c.Name, c => c);
                var products = context.Set<Product>().ToDictionary(p => p.Name, p => p);
                var listings = context.Set<Listing>().ToDictionary(l => l.tpu_id, l => l);

                string csvpath = Path.Combine(environment.ContentRootPath, "Data/Source/Clean/2025-08.csv");
                using (var reader = new StreamReader(csvpath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<CSVRecord>();

                    foreach (var record in records)
                    {
                        if (!chips.ContainsKey(record.chip))
                        {
                            var chip = new Chip
                            {
                                Name = record.chip,
                                foundry = ConvertHelper.SafeStringToNullableString(record.foundry),
                                process_size = ConvertHelper.SafeFloatToInt(record.process_size),
                                transistors = ConvertHelper.SafeFloatToInt(record.transistors),
                                density = record.density,
                                die_size = ConvertHelper.SafeFloatToInt(record.die_size),
                                chip_package = ConvertHelper.SafeStringToNullableString(record.chip_package),
                                directx_major_version = ConvertHelper.SafeFloatToInt(record.directx_major_version),
                                directx_minor_version = ConvertHelper.SafeFloatToInt(record.directx_minor_version),
                                opencl_major_version = ConvertHelper.SafeFloatToInt(record.opencl_major_version),
                                opencl_minor_version = ConvertHelper.SafeFloatToInt(record.opencl_minor_version),
                                vulkan_major_version = ConvertHelper.SafeFloatToInt(record.vulkan_major_version),
                                vulkan_minor_version = ConvertHelper.SafeFloatToInt(record.vulkan_minor_version),
                                opengl_major_version = ConvertHelper.SafeFloatToInt(record.opengl_major_version),
                                opengl_minor_version = ConvertHelper.SafeFloatToInt(record.opengl_minor_version),
                                cuda_major_version = ConvertHelper.SafeFloatToInt(record.cuda_major_version),
                                cuda_minor_version = ConvertHelper.SafeFloatToInt(record.cuda_minor_version),
                                shader_model_major_version = ConvertHelper.SafeFloatToInt(record.shader_model_major_version),
                                shader_model_minor_version = ConvertHelper.SafeFloatToInt(record.shader_model_minor_version)
                            };
                            context.Set<Chip>().Add(chip);
                            chips.Add(record.chip, chip);
                        }

                        if (!products.ContainsKey(record.product))
                        {
                            var product = new Product
                            {
                                Name = record.product, tensor_cores = record.tensor_cores, rt_cores = record.rt_cores
                            };
                            context.Set<Product>().Add(product);
                            products.Add(record.product, product);
                        }

                        Chip _chip = chips[record.chip];
                        Product _product = products[record.product];

                        var listing = new Listing
                        {
                            Product = _product, Chip = _chip,
                            architecture = record.architecture, generation = record.generation, manufacturer = record.manufacturer,
                            base_clock = (int)(record.base_clock), boost_clock = (int)(record.boost_clock), memory_clock = ConvertHelper.SafeFloatToInt(record.memory_clock),
                            release_date = record.release_date, bus_interface = ConvertHelper.SafeStringToNullableString(record.bus_interface), memory_size = record.memory_size,
                            memory_bus = ConvertHelper.SafeFloatToInt(record.memory_bus), memory_bandwidth = record.memory_bandwidth, memory_type = record.memory_type,
                            shading_units = record.shading_units, tmus = record.tmus, rops = record.rops, smus = record.smus,
                            l1_cache = record.l1_cache, l2_cache = record.l2_cache,
                            tdp = ConvertHelper.SafeFloatToInt(record.tdp), board_length  = ConvertHelper.SafeFloatToInt(record.board_length), board_width = ConvertHelper.SafeFloatToInt(record.board_width),
                            board_slot_width = ConvertHelper.SafeStringToNullableString(record.board_slot_width), suggested_psu = ConvertHelper.SafeFloatToInt(record.suggested_psu),
                            power_connectors = ConvertHelper.SafeStringToNullableString(record.power_connectors), display_connectors = ConvertHelper.SafeStringToNullableString(record.display_connectors),
                            pixel_rate = record.pixel_rate, texture_rate = record.texture_rate, 
                            fp16 = record.fp16, fp32 = record.fp32, fp64 = record.fp64,
                            tpu_id = record.tpu_id, tpu_url = record.tpu_url
                        };

                        if (!listings.ContainsKey(record.tpu_id))
                        {
                            context.Set<Listing>().Add(listing);
                            listings.Add(record.tpu_id, listing);
                        }
                    }
                }

                context.SaveChanges();
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}