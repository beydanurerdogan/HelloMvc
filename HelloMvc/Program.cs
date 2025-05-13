using HelloMvc.Models; // DbContext'in bulunduğu namespace
using Microsoft.EntityFrameworkCore;

namespace HelloMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


           
            builder.Services.AddDbContext<OgrenciDBContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("OgrenciDB")));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

          
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
