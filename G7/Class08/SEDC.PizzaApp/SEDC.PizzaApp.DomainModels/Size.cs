namespace SEDC.PizzaApp.DomainModels
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Size()
        {

        }

        public Size(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
