using Microsoft.Extensions.DependencyInjection;
using PizzaApp.Refactored._07.DataAccess;
using PizzaApp.Refactored._07.Domain;
using PizzaApp.Refactored._07.Services;

namespace System // Piggybacking
{
    public static class DependencyInjectionHelper
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPizzaService, PizzaService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IPizzaRepository, PizzaRepository>();
        }
    }
}
