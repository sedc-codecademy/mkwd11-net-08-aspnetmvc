using Domain.Models;

namespace SEDC.PizzaApp.Models.Domain
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsOnPromotion { get; set; }
    }
}
