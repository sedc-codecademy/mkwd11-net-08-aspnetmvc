using SEDC.PizzaApp.Refactored.ViewModels.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Services.Interfaces
{
    public interface IPizzaService
    {
        //method that gets all pizzas for dropdown
        List<PizzaDropDownViewModel> GetAllPizzasForDropdown();
    }
}
