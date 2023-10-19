using Microsoft.EntityFrameworkCore;
using SiteProduct.Db;
using SiteProduct.Services;

namespace SiteProduct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //var conn = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<Repository>(opt => opt.UseSqlServer(conn));
            //builder.Services.AddScoped<IProductData, SqlProductData>();
            //builder.Services.AddScoped<ITypeProductData, SqlTypeProductData>();
            builder.Services.AddScoped<IProductData, DapperProductData>();
            builder.Services.AddScoped<ITypeProductData, DapperTypeProductData>();
            builder.Services.AddMvc();
            var app = builder.Build();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}