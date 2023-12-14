using Microsoft.EntityFrameworkCore;
using WebApplicationPustok.Context;
using WebApplicationPustok.Helpers;


namespace WebApplicationPustok
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

             builder.Services.AddControllersWithViews();
           

            builder.Services.AddDbContext<PustokDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));


            builder.Services.AddScoped<LayoutService>();
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
               name: "areas",
               pattern: "{area:exists}/{controller=Home}/{action=Slider}/{id?}"
               );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            PathConstants.RootPath = builder.Environment.WebRootPath;

            app.Run();
        }
    }
}