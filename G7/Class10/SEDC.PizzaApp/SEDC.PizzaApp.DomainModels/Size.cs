namespace SEDC.PizzaApp.DomainModels
{
    public class Size : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Diameter { get; set; }
        
        public Size() : base()
        {

        }

        public Size(int id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }
    }
}
