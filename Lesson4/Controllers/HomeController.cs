using Lesson4.Data;
using Lesson4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext _context;

        public HomeController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Select(p => new ProductViewModel
            {
                Name=p.Name,
                Price=p.Price
            });

            var categories = _context.Categories.Select(c => new CategoryViewModel { Title = c.Name });

            var vm = new ProductCategoryListViewModel
            {
                Products = products.ToList(),
                Categories = categories.ToList()
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();  
        }
    }
}
