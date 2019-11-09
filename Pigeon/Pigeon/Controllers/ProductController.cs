using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pigeon.Data;

namespace Pigeon.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ProductList(string category)
        {
            ViewBag.Category = category;
            var productList = _context.Products.Where(x => x.Category == category).ToList();
            return PartialView(productList);
        }
    }
}
