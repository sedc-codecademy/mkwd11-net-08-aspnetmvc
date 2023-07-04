using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.ViewModels.Orders
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsDelivered { get; set; }
        public int TotalPrice { get; set; }
        public List<string> PizzaNames { get; set; }
    }
}
