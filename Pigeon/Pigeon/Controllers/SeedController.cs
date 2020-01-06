using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pigeon.Data;

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
            _context.AddRange(Products);
            _context.SaveChanges();
            return new ObjectResult("OK");
        }

        private List<Product> Products = new List<Product>
        {
            new Product
            {
                Barcode = "NB001",
                Category = "Nabiał",
                Description = "Mleko 2% od polskich krów, wolne od GMO, bezglutenowe",
                Name = "Melko 2% Krasnystaw",
                Price = 1.99m
            },
            new Product
            {
                Barcode = "NB002",
                Category = "Nabiał",
                Description = "Jogurt naturalny, zawiera kolektury bakterii, smak truskawkowy",
                Name = "Truskawkowy jogurt naturalny",
                Price = 2.40m
            },
            new Product
            {
                Barcode = "NB002",
                Category = "Nabiał",
                Description = "Jogurt naturalny, zawiera kolektury bakterii, smak truskawkowy",
                Name = "Truskawkowy jogurt naturalny",
                Price = 2.40m
            },
            new Product
            {
                Barcode = "NB002",
                Category = "Nabiał",
                Description = "Jogurt naturalny, zawiera kolektury bakterii, smak truskawkowy",
                Name = "Truskawkowy jogurt naturalny",
                Price = 2.40m
            },
            new Product
            {
                Barcode = "NB002",
                Category = "Nabiał",
                Description = "Jogurt naturalny, zawiera kolektury bakterii, smak truskawkowy",
                Name = "Truskawkowy jogurt naturalny",
                Price = 2.40m
            },
            new Product
            {
                Barcode = "NB002",
                Category = "Nabiał",
                Description = "Jogurt naturalny, zawiera kolektury bakterii, smak truskawkowy",
                Name = "Truskawkowy jogurt naturalny",
                Price = 2.40m
            },
            new Product
            {
                Barcode = "NB002",
                Category = "Nabiał",
                Description = "Jogurt naturalny, zawiera kolektury bakterii, smak truskawkowy",
                Name = "Truskawkowy jogurt naturalny",
                Price = 2.40m
            }
        };
    }
}
