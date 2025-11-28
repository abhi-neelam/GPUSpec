using GPUSpecServer.Data;
using GPUSpecServer.Data.Models;
using GPUSpecServer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GPUSpecServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoritesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("toggle/{listingId}")]
        public async Task<IActionResult> ToggleFavorite(int listingId)
        {
            var userId = _userManager.GetUserId(User);

            var existing = await _context.Favorites.FirstOrDefaultAsync(f => f.UserId == userId && f.ListingId == listingId);

            if (existing != null)
            {
                _context.Favorites.Remove(existing);
                await _context.SaveChangesAsync();
                return Ok(new { isFavorite = false });
            }

            _context.Favorites.Add(new Favorite
            {
                UserId = userId!,
                ListingId = listingId
            });

            await _context.SaveChangesAsync();
            return Ok(new { isFavorite = true });
        }

        [HttpGet]
        public async Task<ActionResult<List<ListingDTO>>> GetFavorites()
        {
            var userId = _userManager.GetUserId(User);

            var favorites = await _context.Favorites
                .Where(f => f.UserId == userId)
                .Select(f => f.Listing!)
                .Select(ListingDTO.Projection)
                .ToListAsync();

            return Ok(favorites);
        }

        [HttpGet("{listingId}")]
        public async Task<IActionResult> GetFavorite(int listingId)
        {
            var userId = _userManager.GetUserId(User);
            var isFavorite = await _context.Favorites.AnyAsync(f => f.UserId == userId && f.ListingId == listingId);

            return Ok(new { isFavorite });
        }
    }
}
