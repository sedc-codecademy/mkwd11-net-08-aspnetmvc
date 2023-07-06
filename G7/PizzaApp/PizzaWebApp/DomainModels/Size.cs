namespace DomainModels
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Size()
        {

        }

        public Size(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
