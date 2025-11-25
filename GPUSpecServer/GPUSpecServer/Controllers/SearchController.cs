using GPUSpecServer.Data;
using GPUSpecServer.Data.Models;
using GPUSpecServer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GPUSpecServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        private IQueryable<Listing> SearchQuery(IQueryable<Listing> query, string q)
        {
            query = query.Where(l => l.Product.Name.ToLower().Contains(q.ToLower()));
            return query;
        }

        // GET: api/Search
        [HttpGet]
        public async Task<ActionResult<PagedResult<ListingDTO>>> SearchListings([FromQuery] string q, int pageIndex = 1, int pageSize = 10, string orderBy = "desc")
        {
            var query = SearchQuery(_context.Listings.AsNoTracking(), q).Select(ListingDTO.Projection);
            return await PagedResult<ListingDTO>.CreateAsync(query, pageIndex, pageSize, "release_date", orderBy);
        }
    }
}
