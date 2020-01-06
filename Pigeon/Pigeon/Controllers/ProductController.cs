using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pigeon.Data;
using Pigeon.Models;
using Pigeon.PandaSystem;
using Pigeon.PandaSystem.Models;
using ProductDto = Pigeon.PandaSystem.Models.ProductDto;

namespace Pigeon.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPandaApi _pandaApi;

        public ProductController(ApplicationDbContext context, IPandaApi pandaApi)
        {
            _context = context;
            _pandaApi = pandaApi;
        }

        public IActionResult ProductList(string category)
        {
            ViewBag.Category = category;
            var productList = _context.Products.Where(x => x.Category == category).ToList();
            return PartialView(productList);
        }


        public IActionResult Create()
        {
            return View(new CreateProduct());
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirmed(CreateProduct model)
        {
            var dbProduct = new Product
            {
                Barcode = model.Barcode,
                Category = model.Category,
                Count = model.Count,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price
            };
            _context.Products.Add(dbProduct);
            _context.SaveChanges();

            var products = _context.Products
                .Select(x => new ProductDto
                {
                    Barcode = x.Barcode,
                    Count = x.Count,
                    Description = x.Description,
                    Id = x.ProductId.ToString(),
                    Name = x.Name,
                    Price = x.Price
                })
                .ToList();

            var request = new BulkUpdateRequest
            {
                ShopUniqueCode = "ccc_58i9_APX30x_40pFfg",
                Products = products
            };

            await _pandaApi.BulkUpdate(request);

            return RedirectToAction("Index", "Home");
        }
    }
}
