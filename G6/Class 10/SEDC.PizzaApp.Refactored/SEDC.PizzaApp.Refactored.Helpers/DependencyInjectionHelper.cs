using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.Refactored.DataAccess;
using SEDC.PizzaApp.Refactored.DataAccess.EFImplementations;
using SEDC.PizzaApp.Refactored.DataAccess.Implementations;
using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;
using SEDC.PizzaApp.Refactored.Domain.Users;
using SEDC.PizzaApp.Refactored.Services.Implementations;
using SEDC.PizzaApp.Refactored.Services.Interfaces;

namespace SEDC.PizzaApp.Refactored.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IRepository<Order>, OrderRepository>();
            //services.AddTransient<IRepository<Pizza>, PizzaRepository>();
            //services.AddTransient<IRepository<User>, UserRepository>();

            services.AddTransient<IRepository<Order>, OrderEFRepository>();
            //services.AddTransient<IRepository<Pizza>, PizzaEFRepository>();
            services.AddTransient<IPizzaRepository, PizzaEFRepository>();
            services.AddTransient<IRepository<User>, UserEFRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPizzaService, PizzaService>();
        }

        public static void InjectDbContext(IServiceCollection services)
        {
            // Server=.\\SQLEXPRESS
            services.AddDbContext<PizzaAppDbContext>(options =>
            options.UseSqlServer("Server=SKL-TANJA-STOJA\\SQLEXPRESS;Database=PizzaAppDb;Trusted_Connection=True;TrustServerCertificate=true"));
        }
    }
}
