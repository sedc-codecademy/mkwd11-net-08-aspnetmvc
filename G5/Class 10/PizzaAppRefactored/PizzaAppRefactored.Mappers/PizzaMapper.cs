using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.ViewModels.PizzaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaOptionsViewModel ToPizzaOptionsViewModel(Pizza pizza)
        {
            return new PizzaOptionsViewModel
            {
                Id = pizza.Id,
                PizzaName = pizza.Name
            };
        }
    }
}
