using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.Refactored.DataAccess.Data;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.EntityFrameworkImplementation;
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
            services.AddTransient<IPizzaService, PizzaService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            //static db
            //services.AddTransient<IRepository<Order>, OrderRepository>();
            //services.AddTransient<IRepository<User>, UserRepository>();
            //services.AddTransient<IPizzaRepository, PizzaRepository>();

            // entity framework
            services.AddTransient<IRepository<Order>, OrderRepositoryEntity>();
            services.AddTransient<IRepository<User>, UserRepositoryEntity>();
            services.AddTransient<IPizzaRepository, PizzaRepositoryEntity>();
        }

        public static void InjectDbContext(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<PizzaAppDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }
    }
}
