using Fiorello.DAL;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.ViewComponents
{
    public class BioViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public BioViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            List<Bio> bios = await _dbContext.Bios
                .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            return View(bios);
        }
    }
}
