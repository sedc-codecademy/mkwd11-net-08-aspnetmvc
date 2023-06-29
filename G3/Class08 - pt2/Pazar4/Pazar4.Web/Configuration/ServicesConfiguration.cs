using Pazar4.BLL.Hashing;
using Pazar4.BLL.Providers;
using Pazar4.BLL.Services;
using Pazar4.BLL.Services.External;

namespace Pazar4.Web.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ISellerService, SellerService>();
            services.AddSingleton<IPasswordHasher, DummyPasswordHasher>();
            services.AddSingleton<IConfirmationCodeProvider, SimpleConfirmationCodeProvider>();
            services.AddSingleton<IEmailSender, GoogleMailSender>();
            return services;
        }
    }
}
