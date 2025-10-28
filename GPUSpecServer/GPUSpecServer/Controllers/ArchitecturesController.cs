using GPUSpecServer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GPUSpecServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchitecturesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArchitecturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Architectures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetGenerations()
        {
            return await _context.Listings.Select(l => l.architecture).Distinct().ToListAsync();
        }
    }
}
