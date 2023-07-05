using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaApp.Refactored._09.DataAccess;
using PizzaApp.Refactored._09.Domain;
using PizzaApp.Refactored._09.Services;

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
            // Using staticDB ( Uncomment to use StaticDB )
            //services.AddTransient<IRepository<Order>, OrderRepository>();
            //services.AddTransient<IRepository<User>, UserRepository>();
            //services.AddTransient<IPizzaRepository, PizzaRepository>();

            // Using EntityFramework
            services.AddTransient<IRepository<Order>, OrderEFRepository>();
            services.AddTransient<IRepository<User>, UserEFRepository>();
            services.AddTransient<IPizzaRepository, PizzaEFRepository>();
        }

        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<PizzaAppDbContext>(options =>
                options.UseSqlServer("Server=SKL-TANJA-STOJA\\SQLEXPRESS;Database=PizzaAppDbTest;Trusted_Connection=True")
            );
        }
    }
}
