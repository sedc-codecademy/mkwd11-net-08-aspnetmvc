using SEDC.PizzaApp.Refactored.DataAccess.Implementations;
using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;
using SEDC.PizzaApp.Refactored.Domain.Users;
using SEDC.PizzaApp.Refactored.Services.Implementations;
using SEDC.PizzaApp.Refactored.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
//wherever we meet IRepository<Order>, assign OrderRepository implementation
builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
//builder.Services.AddTransient<IRepository<Order>, SecondOrderRepository>();
builder.Services.AddTransient<IRepository<Pizza>, PizzaRepository>();
builder.Services.AddTransient<IRepository<User>, UserRepository>();

builder.Services.AddTransient<IOrderService, OrderService>();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
