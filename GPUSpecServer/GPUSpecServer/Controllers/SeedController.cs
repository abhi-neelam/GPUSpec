using GPUSpecServer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Formats.Asn1;
using System.Globalization;

namespace GPUSpecServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        IHostEnvironment environment;
        string? csvpath = null;

        public SeedController(ApplicationDbContext context, IHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
            csvpath = Path.Combine(environment.ContentRootPath, "Data/Source/Clean/2025-08.csv");
        }
    }
}
