namespace DemoWebApp.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developers { get; set; }
        public CategoryEnum Category { get; set; }
        public int PEGI { get; set; }
        public string Description { get; set; }
    }
}
