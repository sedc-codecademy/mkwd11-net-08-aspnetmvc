using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public int NumberOfOrdersInTheApp { get; set; }
        public List<string> PizzasOnPromotion { get; set; }
    }
}
