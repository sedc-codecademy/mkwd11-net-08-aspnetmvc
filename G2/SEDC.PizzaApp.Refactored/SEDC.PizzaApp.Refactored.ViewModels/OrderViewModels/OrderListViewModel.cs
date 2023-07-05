using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public bool Delivered { get; set; }
        public List<string> PizzaNames { get; set; }
    }
}
