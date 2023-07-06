using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.StaticDbImplementation;
using SEDC.PizzaApp.Refactored.Domain.Models;
using SEDC.PizzaApp.Refactored.Services;
using SEDC.PizzaApp.Refactored.Services.Abstraction;

namespace SEDC.PizzaApp.Refactored.Helpers
{
    // package Microsoft.Extensions.DependencyInjection.Abstractions v6.0.0
    public static class DependencyInjectionHelper
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
        }
    }
}
