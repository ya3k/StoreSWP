using Microsoft.EntityFrameworkCore;
using StoreSWP.Data;
using StoreSWP.Interface;
using StoreSWP.Repository;

namespace StoreSWP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //add repositery
            builder.Services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();

            //get connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapControllerRoute(
            //  name: "default",
            //  pattern: "{controller=Store}/{action=SearchByName}/{name?}");
            app.Run();
        }
    }
}