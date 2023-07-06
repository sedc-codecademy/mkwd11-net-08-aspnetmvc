using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    //[Table("Pizza")]
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //[Column("URL")]
        public string ImageUrl { get; set; }

        public Pizza()
        {

        }

        public Pizza(string name, string description, string imageUrl)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
