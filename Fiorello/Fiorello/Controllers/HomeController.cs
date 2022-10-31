using Fiorello.DAL;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.HomeControllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {

#pragma warning disable CS8604 // Possible null reference argument.
            Slider slider = await _dbContext.Sliders
                .SingleAsync();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
            List<SliderImage> sliderImages = await _dbContext.SliderImages
                .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
            List<Category> categories = await _dbContext.Categories
                .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
            List<Product> products = await _dbContext.Products
                .Include(pro=>pro.Category)
                .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            var homeViewModel = new HomeViewModel
            {
                Slider = slider,
                SliderImage = sliderImages,
                Category = categories,
                Product=products,
            };

            return View(homeViewModel);
        }
    }
}
