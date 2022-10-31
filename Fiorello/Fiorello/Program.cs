using Fiorello.DAL;
using Microsoft.EntityFrameworkCore;

namespace Fiorello
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc();
            builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => app.MapControllerRoute(
                "default", "{controller=home}/{action=index}/{id?}"
                ));
            app.Run();
        }
    }
}