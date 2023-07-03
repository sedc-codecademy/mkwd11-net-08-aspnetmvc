namespace PizzaApp.Helpers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PizzaApp.DataAccess.DataContext;
    using PizzaApp.DataAccess.Repositories.Implementations;
    using PizzaApp.DataAccess.Repositories.Interfaces;
    using PizzaApp.Domain.Models;
    using PizzaApp.Services.Implementations;
    using PizzaApp.Services.Interfaces;

    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<PizzaAppDbContext>(options =>
            options.UseSqlServer(@"Data Source=(localdb)\LocalTest;Database=PizzaAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Pizza>, PizzaRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IPizzaService, PizzaService>();
        }
    };
}
