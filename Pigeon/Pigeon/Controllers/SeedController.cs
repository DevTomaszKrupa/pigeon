using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pigeon.Data;
using Pigeon.Models;

namespace Pigeon.Controllers
{
    public class SeedController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SeedController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var seed = ReadJsonFile();
            var products = seed.Products.Select(x => new Product
            {
                Name = x.Name,
                Barcode = x.Barcode,
                Count = x.Count,
                Category = x.Category,
                Description = x.Description,
                Price = x.Price
            }).ToList();
            _context.Products.AddRange(products);
            _context.SaveChanges();
            return new ObjectResult("OK");
        }

        public IActionResult Truncate()
        {
            var allItems = _context.Products.ToList();
            _context.Products.RemoveRange(allItems);
            _context.SaveChanges();
            return new ObjectResult("OK");
        }

        private SeedData ReadJsonFile()
        {
            using (var r = new StreamReader("SeedProducts.json"))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<SeedData>(json);
            }
        }
    }
}
