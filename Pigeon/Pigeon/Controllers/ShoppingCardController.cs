using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pigeon.Data;
using Pigeon.Models;

namespace Pigeon.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToCard([FromBody] AddToCardRequest request)
        {
            var shoppingCard = _context.ShoppingCards.FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (shoppingCard == null)
            {
                shoppingCard = new ShoppingCard { UserName = User.Identity.Name };
                _context.ShoppingCards.Add(shoppingCard);
                _context.SaveChanges();
            }

            var shoppingCardProduct = _context.ShoppingCardProducts.FirstOrDefault(x =>
                x.ShoppingCardId == shoppingCard.ShoppingCardId && x.ProductId == request.ProductId);
            if (shoppingCardProduct == null)
            {
                shoppingCardProduct = new ShoppingCardProduct
                {
                    Count = request.Count,
                    ProductId = request.ProductId,
                    ShoppingCardId = shoppingCard.ShoppingCardId
                };
                _context.ShoppingCardProducts.Add(shoppingCardProduct);
            }
            else
            {
                shoppingCardProduct.Count += request.Count;
            }
            _context.SaveChanges();

            var shoppingCardProducts = _context.ShoppingCards
                .Where(x => x.UserName == User.Identity.Name)
                .SelectMany(x => x.ShoppingCardProducts)
                .Count();

            return new ObjectResult(shoppingCardProducts);
        }
    }
}
