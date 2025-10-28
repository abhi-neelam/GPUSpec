using GPUSpecServer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GPUSpecServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenerationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Generations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetGenerations()
        {
            return await _context.Listings.Select(l => l.generation).Distinct().ToListAsync();
        }
    }
}
