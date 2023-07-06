namespace SEDC.PizzaApp.Refactored.ViewModels.Orders
{
    //this viewmodel will be used when showing list of orders
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public int TotalPrice { get; set; }
    }
}
