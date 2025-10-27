using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GPUSpecServer.Data;
using GPUSpecServer.Data.Models;

namespace GPUSpecServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Chips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chip>>> GetChips()
        {
            return await _context.Chips.ToListAsync();
        }

        // GET: api/Chips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chip>> GetChip(int id)
        {
            var chip = await _context.Chips.FindAsync(id);

            if (chip == null)
            {
                return NotFound();
            }

            return chip;
        }
    }
}
