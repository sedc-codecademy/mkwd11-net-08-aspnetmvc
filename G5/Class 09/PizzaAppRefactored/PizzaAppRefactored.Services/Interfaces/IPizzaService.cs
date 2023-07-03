using PizzaAppRefactored.ViewModels.PizzaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Services.Interfaces
{
    public interface IPizzaService
    {
        List<PizzaOptionsViewModel> GetPizzasForDropdown();
    }
}
