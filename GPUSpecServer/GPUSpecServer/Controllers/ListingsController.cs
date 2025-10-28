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
        public async Task<ActionResult<PagedResult<ListingDTO>>> GetListings([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string orderBy = "desc")
        {
            var query = _context.Listings.AsNoTracking().Select(ListingDTO.Projection);
            return await PagedResult<ListingDTO>.CreateAsync(query, pageIndex, pageSize, "release_date", orderBy);
        }

        // GET: api/Listings/Manufacturer/NVIDIA
        [HttpGet("Manufacturer/{manufacturer}")]
        public async Task<ActionResult<PagedResult<ListingDTO>>> GetManufacturerListings(string manufacturer, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string orderBy = "desc")
        {
            var query = _context.Listings.AsNoTracking().Where(l => l.manufacturer.ToLower() == manufacturer.ToLower()).Select(ListingDTO.Projection);
            return await PagedResult<ListingDTO>.CreateAsync(query, pageIndex, pageSize, "release_date", orderBy);
        }

        // GET: api/Listings/Architecture/NVIDIA
        [HttpGet("Architecture/{architecture}")]
        public async Task<ActionResult<PagedResult<ListingDTO>>> GetArchitectureListings(string architecture, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string orderBy = "desc")
        {
            var query = _context.Listings.AsNoTracking().Where(l => l.architecture.ToLower() == architecture.ToLower()).Select(ListingDTO.Projection);
            return await PagedResult<ListingDTO>.CreateAsync(query, pageIndex, pageSize, "release_date", orderBy);
        }

        // GET: api/Listings/Generation/NVIDIA
        [HttpGet("Generation/{generation}")]
        public async Task<ActionResult<PagedResult<ListingDTO>>> GetGenerationListings(string generation, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string orderBy = "desc")
        {
            var query = _context.Listings.AsNoTracking().Where(l => l.generation.ToLower() == generation.ToLower()).Select(ListingDTO.Projection);
            return await PagedResult<ListingDTO>.CreateAsync(query, pageIndex, pageSize, "release_date", orderBy);
        }

        // GET: api/Listings/Chip/NVIDIA
        [HttpGet("Chip/{chip}")]
        public async Task<ActionResult<PagedResult<ListingDTO>>> GetChipListings(string chip, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string orderBy = "desc")
        {
            var query = _context.Listings.AsNoTracking().Where(l => l.Chip.Name.ToLower() == chip.ToLower()).Select(ListingDTO.Projection);
            return await PagedResult<ListingDTO>.CreateAsync(query, pageIndex, pageSize, "release_date", orderBy);
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
