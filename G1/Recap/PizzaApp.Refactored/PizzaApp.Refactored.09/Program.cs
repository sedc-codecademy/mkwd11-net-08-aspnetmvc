var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registering Dependency Injection without a helper
// builder.Services.AddTransient<IOrderService, OrderService>();

// Registering Dependency Injection
builder.Services.InjectServices();
builder.Services.InjectRepositories();
builder.Services.InjectDbContext();

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
