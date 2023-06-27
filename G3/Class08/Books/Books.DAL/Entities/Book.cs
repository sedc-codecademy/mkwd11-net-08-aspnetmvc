namespace Books.DAL.Entities
{
    public class Book
        : BaseEntity
    {
        public Book(string name, string author, DateTime published)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Published = published;
        }

        public string Name { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public DateTime Published { get; set; }
    }
}
