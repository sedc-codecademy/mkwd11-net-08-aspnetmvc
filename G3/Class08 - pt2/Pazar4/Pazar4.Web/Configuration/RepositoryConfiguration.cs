using Pazar4.DAL.Entities;
using Pazar4.DAL.Repository;
using Pazar4.StaticDb.Criterias;

namespace Pazar4.Web.Configuration
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Seller, SellerCriteria>, Pazar4.StaticDb.Repository.SellerRepository>();
            //builder.Services.AddScoped<IRepository<Seller>, Pazar4.EF.Repository.SellerRepository>();
            return services;
        }
    }
}
