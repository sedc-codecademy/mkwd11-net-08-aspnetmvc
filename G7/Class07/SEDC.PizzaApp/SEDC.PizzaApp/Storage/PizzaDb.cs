using SEDC.PizzaApp.DomainModels;
using SEDC.PizzaApp.Helpers;

namespace SEDC.PizzaApp.Storage
{
    public static class PizzaDb
    {
        public static List<Size> Sizes = new List<Size>
        {
            new Size(CommonHelper.GetRandomId(), "Small", "20 cm"),
            new Size(CommonHelper.GetRandomId(), "Medium", "30 cm"),
            new Size(CommonHelper.GetRandomId(), "Large", "40 cm"),
            new Size(CommonHelper.GetRandomId(), "Family", "50 cm"),
        };


        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza(CommonHelper.GetRandomId(),"Kaprichioza", "Kecap, kaskaval, pecurki, shunka", "https://media-cdn.tripadvisor.com/media/photo-s/0e/25/5c/f9/pizza-capricciosa-pica.jpg"),
            new Pizza(CommonHelper.GetRandomId(),"Stelato", "Kecap, kaskaval, pecurki, shunka, pavlaka", "https://media.istockphoto.com/id/510306420/photo/pizza-with-loin-sour-cream-and-mushrooms.jpg?s=612x612&w=0&k=20&c=d9iT9uW7aJ04jt57PdUp3s5917JeSwY6pE6AouHeMCw=" ),
            new Pizza(CommonHelper.GetRandomId(),"Pepperoni", "Kecap, kaskaval, pecurki, kulen",  "https://www.simplehomecookedrecipes.com/wp-content/uploads/2021/02/Pepperoni-Pizza-480x270.png")
        };

        public static List<MenuItem> MenuItems = new List<MenuItem>
        {
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[0], Sizes[0], 150),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[0], Sizes[1], 230),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[0], Sizes[2], 300),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[0], Sizes[3], 400),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[1], Sizes[0], 180),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[1], Sizes[1], 260),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[1], Sizes[2], 330),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[1], Sizes[3], 430),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[2], Sizes[0], 170),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[2], Sizes[1], 250),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[2], Sizes[2], 320),
            new MenuItem(CommonHelper.GetRandomId(), Pizzas[2], Sizes[3], 400)
        };

        public static List<Order> Orders = new List<Order>();
    }
}
