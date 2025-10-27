using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GPUSpecServer.Data;
using GPUSpecServer.Data.Models;
using GPUSpecServer.DTOs;

namespace GPUSpecServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ListingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Listings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListingDTO>>> GetListings()
        {
            return await _context.Listings.Include(p => p.Product).Include(c => c.Chip).Select(l => new ListingDTO { Id = l.Id, ChipId = l.ChipId, ProductId = l.ProductId, chip = l.Chip.Name, product = l.Product.Name, architecture = l.architecture, generation = l.generation, manufacturer = l.manufacturer, memory_size = l.memory_size, release_date = l.release_date, foundry = l.Chip.foundry, process_size=l.Chip.process_size }).ToListAsync();
        }

        // GET: api/Listings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Listing>> GetListing(int id)
        {
            var listing = await _context.Listings.Include(p => p.Product).Include(c => c.Chip).SingleAsync(n => n.Id == id);

            if (listing == null)
            {
                return NotFound();
            }

            return listing;
        }
    }
}
