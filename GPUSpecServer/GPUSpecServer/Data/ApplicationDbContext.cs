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
    }
}
