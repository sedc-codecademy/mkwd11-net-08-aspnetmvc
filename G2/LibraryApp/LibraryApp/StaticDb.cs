using LibraryApp.Models;

namespace LibraryApp
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book 
            {
                Id = 1,
                Title = "Kasni Porasni"
            },
            new Book
            {
                Id = 2,
                Title = "Zoki Poki"
            },
            new Book
            {
                Id = 3,
                Title = "35 Maj"
            }
        };
    }
}
