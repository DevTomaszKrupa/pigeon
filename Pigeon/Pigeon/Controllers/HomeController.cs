using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pigeon.Data;
using Pigeon.Models;

namespace Pigeon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var shoppingCardProducts = _context.ShoppingCards
                .Where(x => x.UserName == User.Identity.Name)
                .SelectMany(x => x.ShoppingCardProducts)
                .Count();
            ViewBag.ShoppingCardCount = shoppingCardProducts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
