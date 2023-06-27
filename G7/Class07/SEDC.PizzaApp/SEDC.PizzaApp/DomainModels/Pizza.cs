using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace SEDC.PizzaApp.DomainModels
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public Pizza()
        {

        }
        public Pizza(int id, string name, string description, string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
