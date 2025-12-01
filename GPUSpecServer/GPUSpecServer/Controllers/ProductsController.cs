using GPUSpecServer.Data;
using GPUSpecServer.Data.Models;
using GPUSpecServer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPUSpecServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<PagedResult<Product>>> GetProducts([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var query = _context.Products.AsNoTracking();

            return await PagedResult<Product>.CreateAsync(
                query,
                p => p,
                pageIndex,
                pageSize,
                "Name",
                "asc");
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
    }
}
