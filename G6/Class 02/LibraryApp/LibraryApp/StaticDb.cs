using LibraryApp.Models;

namespace LibraryApp
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "First title",
                Author = "First author"
            },
            new Book()
            {
                Id = 2,
                Title = "Second title",
                Author = "Second author"
            },
            new Book()
            {
                Id = 3,
                Title = "Third title",
                Author = "Third author"
            }
        };
    }
}
