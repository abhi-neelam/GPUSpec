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

        private IQueryable<Listing> FilterQuery(IQueryable<Listing> query, ListingSearchParams searchParams) {
            if (!string.IsNullOrEmpty(searchParams.q))
            {
                query = query.Where(l => l.Product.Name.ToLower().Contains(searchParams.q.ToLower()));
            }

            if (!string.IsNullOrEmpty(searchParams.manufacturer)) {
                query = query.Where(l => l.manufacturer.ToLower() == searchParams.manufacturer.ToLower());
            }

            if (!string.IsNullOrEmpty(searchParams.architecture))
            {
                query = query.Where(l => l.architecture.ToLower() == searchParams.architecture.ToLower());
            }

            if (!string.IsNullOrEmpty(searchParams.generation))
            {
                query = query.Where(l => l.generation.ToLower() == searchParams.generation.ToLower());
            }

            if (!string.IsNullOrEmpty(searchParams.product))
            {
                query = query.Where(l => l.Product.Name.ToLower() == searchParams.product.ToLower());
            }

            if (!string.IsNullOrEmpty(searchParams.chip))
            {
                query = query.Where(l => l.Chip.Name.ToLower() == searchParams.chip.ToLower());
            }

            if (searchParams.min_release_year.HasValue)
            {
                query = query.Where(l => l.release_date.HasValue && l.release_date.Value.Year >= searchParams.min_release_year.Value);
            }

            if (searchParams.max_release_year.HasValue)
            {
                query = query.Where(l => l.release_date.HasValue && l.release_date.Value.Year <= searchParams.max_release_year.Value);
            }

            if (searchParams.min_process_size.HasValue)
            {
                query = query.Where(l => l.Chip.process_size.HasValue && l.Chip.process_size >= searchParams.min_process_size.Value);
            }

            if (searchParams.max_process_size.HasValue)
            {
                query = query.Where(l => l.Chip.process_size.HasValue && l.Chip.process_size <= searchParams.max_process_size.Value);
            }

            if (searchParams.min_memory_size.HasValue)
            {
                query = query.Where(l => l.memory_size >= searchParams.min_memory_size.Value);
            }

            if (searchParams.max_memory_size.HasValue)
            {
                query = query.Where(l => l.memory_size <= searchParams.max_memory_size.Value);
            }

            if (searchParams.min_memory_bus.HasValue)
            {
                query = query.Where(l => l.memory_bus.HasValue && l.memory_bus >= searchParams.min_memory_bus.Value);
            }

            if (searchParams.max_memory_bus.HasValue)
            {
                query = query.Where(l => l.memory_bus.HasValue && l.memory_bus <= searchParams.max_memory_bus.Value);
            }

            if (!string.IsNullOrEmpty(searchParams.memory_type))
            {
                query = query.Where(l => l.memory_type.ToLower() == searchParams.memory_type.ToLower());
            }

            if (!string.IsNullOrEmpty(searchParams.slot_width))
            {
                query = query.Where(l => !string.IsNullOrEmpty(l.board_slot_width) && l.board_slot_width.ToLower() == searchParams.slot_width.ToLower());
            }

            return query;
        }

        // GET: api/Listings
        [HttpGet]
        public async Task<ActionResult<PagedResult<ListingDTO>>> GetListings([FromQuery] ListingSearchParams searchParams, int pageIndex = 1, int pageSize = 10, string orderBy = "desc")
        {
            var query = FilterQuery(_context.Listings.AsNoTracking(), searchParams).Select(ListingDTO.Projection);
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
