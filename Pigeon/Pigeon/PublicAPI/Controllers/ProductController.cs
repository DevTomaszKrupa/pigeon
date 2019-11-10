using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pigeon.Data;
using Pigeon.PublicAPI.Models;

namespace Pigeon.PublicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            var items = _context.Products
                .Select(x => new ApiProduct(x.ProductId.ToString(), x.Name, x.Price, x.Barcode))
                .ToList();
            return Ok(items);
        }
    }
}
