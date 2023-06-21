using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Refactored._06.Domain
{
    public class PizzaOrder : BaseEntity
    {
        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public PizzaSizeEnum PizzaSize { get; set; }
    }
}
