using Fiorello.DAL;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.ViewComponents
{
    public class DiscountProductsViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public DiscountProductsViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            List<Product> products = await _dbContext.Products
                .Where(p => p.DiscountDegree != null)
                .Include(p=>p.Category)
                .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            return View(products);

        }
    }
}
