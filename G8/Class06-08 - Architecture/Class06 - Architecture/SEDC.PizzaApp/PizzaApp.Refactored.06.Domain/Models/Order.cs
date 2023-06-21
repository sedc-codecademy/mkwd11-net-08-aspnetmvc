using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Refactored._06.Domain
{
    public class Order : BaseEntity
    {
        public PaymentMethodEnum PaymentMethod { get; set; }
        public bool Delivered { get; set; }
        public string Location { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
        public User User { get; set; }
    }
}
