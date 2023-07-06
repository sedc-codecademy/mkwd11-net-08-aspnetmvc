namespace SEDC.PizzaApp.DomainModels
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public Pizza() : base()
        {

        }
        public Pizza(int id, string name, string description, string imageUrl) : base(id)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
