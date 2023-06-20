using Microsoft.AspNetCore.Mvc;
using Models;

namespace ViewsDemoWebApp.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            List<RestaurantViewModel> list = new List<RestaurantViewModel>
            {
                new RestaurantViewModel
                {
                    Name = "Enriko",
                    Location = "Leptokarija",
                    PhoneNumber = "070/123-123",
                    Menu = new List<MenuItemViewModel>
                    {
                        new MenuItemViewModel
                        {
                            Name = "Omlet",
                            Price =200
                        },
                        new MenuItemViewModel
                        {
                            Name = "Pizza",
                            Price = 500
                        }
                    }
                },
                new RestaurantViewModel
                {
                    Name = "Staro bure",
                    Location = "Leptokarija",
                    PhoneNumber = "070/123-124",
                    Menu = new List<MenuItemViewModel>
                    {
                        new MenuItemViewModel
                        {
                            Name = "Sharska",
                            Price =250
                        },
                        new MenuItemViewModel
                        {
                            Name = "Shopska",
                            Price = 180
                        },
                        new MenuItemViewModel
                        {
                            Name = "Pivo",
                            Price = 100
                        }
                    }
                }
            };

            return View(list);
        }
    }
}
