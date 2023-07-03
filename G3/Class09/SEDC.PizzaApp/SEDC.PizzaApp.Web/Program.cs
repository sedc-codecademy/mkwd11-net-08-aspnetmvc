using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.BLL.Services;
using SEDC.PizzaApp.BLL.Services.Implementation;
using SEDC.PizzaApp.Data.Database;
using SEDC.PizzaApp.Data.Models;
using SEDC.PizzaApp.Data.Repositories;
using SEDC.UserApp.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();


builder.Services.AddScoped<IOrderService, OrderService>(); // new O
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Pizza>, PizzaRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlServer<ApplicationDbContext>(connectionString);
//builder.Services.AddNpgsql<ApplicationDbContext>(connectionString);

//builder.Services.AddDbContext<ApplicationDbContext>
//    (options => options.UseNpgsql(connectionString));

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromHours(1);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});
var app = builder.Build();
//app.Use(async (context, next) =>
//{
//    try
//    {
//        await next.Invoke();

//    }
//    catch (Exception ex)
//    {
//        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "");
//        context.Response.Redirect = StatusCodes
//    }
//    Do work that can write to the Response.
//     Do logging or other work that doesn't write to the Response.
//});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
