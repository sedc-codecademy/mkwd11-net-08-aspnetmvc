using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaAppRefactored.DataAccess;
using PizzaAppRefactored.DataAccess.EFImplementations;
using PizzaAppRefactored.DataAccess.Implementations;
using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.Services.Implementations;
using PizzaAppRefactored.Services.Interfaces;

namespace PizzaAppRefactored.Helpers
{
    public static class InjectionHelper
    {
        public static void InjectRepositories (IServiceCollection services)
        {
           // services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Order>, OrderEFRepository>();
           // services.AddTransient<IRepository<Pizza>, PizzaRepository>();
            services.AddTransient<IRepository<Pizza>, PizzaEFRepository>();
          //  services.AddTransient<IRepository<User>, UserRepository>();
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
            services.AddDbContext<PizzaAppDbContext>(options =>
            {
                //local server(our machine), the database is PizzaAppG5, we use Windows credentials
                 options.UseSqlServer("Server=.;Database=PizzaAppG5;Trusted_Connection=True;TrustServerCertificate=True");
                //if you have sqlexpress, you need \\sqlexpress next to the localhost
                //options.UseSqlServer("Server=.\\sqlexpress;Database=PizzaAppDb;Trusted_Connection=True;TrustServerCertificate=True");
            });
        }
    }
}