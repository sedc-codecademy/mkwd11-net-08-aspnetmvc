namespace PizzaApp.Helpers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PizzaApp.DataAccess.DataContext;

    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<PizzaAppDbContext>(options =>
            options.UseSqlServer(@"Data Source=(localdb)\LocalTest;Database=PizzaAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
        }
    };
}
