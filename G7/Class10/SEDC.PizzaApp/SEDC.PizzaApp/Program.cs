using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.DomainModels;
using SEDC.PizzaApp.Services;
using SEDC.PizzaApp.Services.Abstraction;

namespace SEDC.PizzaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ISizeService, SizeService>();
            builder.Services.AddTransient<ISmsService, TMobileSmsService>();
            //builder.Services.AddTransient<IRepository<Size>, SizeRepository>();
            builder.Services.AddTransient<IRepository<Size>, SizeEfRepository>();
            builder.Services.AddTransient<IRepository<MenuItem>, MenuItemRepository>();
            builder.Services.AddTransient<IMenuItemService, MenuItemService>();

            //builder.Services.AddSingleton<ISizeService, SizeService>();
            //builder.Services.AddScoped<ISizeService, SizeService>();

            builder.Services.AddDbContext<PizzaAppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

            app.Run();
        }
    }
}