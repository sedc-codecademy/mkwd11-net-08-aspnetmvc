using DataAccess;

namespace NewsWebApp.Models
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public override string GetInfo()
        {
            return $"{Title}\n{Text}\nAuthor: {Author}";
        }
    }
}
