namespace PizzaApp.Refactored._09.ViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public bool Delivered { get; set; }
        public List<string> PizzaNames { get; set; }
    }
}
