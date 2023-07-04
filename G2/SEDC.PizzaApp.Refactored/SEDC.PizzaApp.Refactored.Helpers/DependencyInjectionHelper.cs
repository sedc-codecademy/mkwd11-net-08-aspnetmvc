using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.StaticDbImplementation;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories;
using SEDC.PizzaApp.Refactored.Domain.Models;
using SEDC.PizzaApp.Refactored.Services;
using SEDC.PizzaApp.Refactored.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Helpers
{
    // package Microsoft.Extensions.DependencyInjection.Abstractions v6.0.0
    public static class DependencyInjectionHelper
    {
        public static void InjectServices(this IServiceCollection services) 
        {
            services.AddTransient<IOrderService, OrderService>();
        }

        public static void InjectRepositories(this IServiceCollection services) 
        {
            services.AddTransient<IRepository<Order>, OrderRepository>();
        }
    }
}
