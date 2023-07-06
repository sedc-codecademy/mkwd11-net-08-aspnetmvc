using SEDC.PizzaApp.Refactored.ViewModels.PizzaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Services.Abstraction
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetPizzasForDropdown();
        string GetPizzaNameOnPromotion();
    }
}
