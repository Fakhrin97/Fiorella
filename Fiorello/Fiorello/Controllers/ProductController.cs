using Fiorello.DAL;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            List<Product> products = await _dbContext.Products
                .Include(p=>p.Category)
                .Take(6)
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

            return View(product);
        }

    }
}
