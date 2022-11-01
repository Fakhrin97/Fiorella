using Fiorello.DAL;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;
        private int _prductCount;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
#pragma warning disable CS8604 // Possible null reference argument.
            _prductCount = dbContext.Products.Count();
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.prductCount = _prductCount;
#pragma warning disable CS8604 // Possible null reference argument.
            List<Product> products = await _dbContext.Products
                .Include(p=>p.Category)
                .Take(4)
                .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (id == null) return NotFound();
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
            Product product = await _dbContext.Products
                .SingleOrDefaultAsync(pId => pId.Id == id);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (product == null) return NotFound();

            return View(product);
        }

        public async Task<IActionResult> Partial(int skip)
        {
            if (skip >= _prductCount)
                return BadRequest();

#pragma warning disable CS8604 // Possible null reference argument.
            List<Product> products = await _dbContext.Products
                .Include(p => p.Category)
                .Skip(skip)
                .Take(4)
                .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            return PartialView("_ProductPartialView", products);
        }

    }
}
