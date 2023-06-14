namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class PizzaOverviewViewModel
    {
        public IEnumerable<PizzaViewModel> Pizzas { get; set; } = new List<PizzaViewModel>();

        public UserViewModel User { get; set; }
    }
}
