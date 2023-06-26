using Books.BLL.Models;

namespace Books.BLL.Services
{
    public interface IBookService
    {
        BookModel GetBook(int id);
        
        IEnumerable<BookModel> GetBooks();

        BookModel Update(BookModel model);

        BookModel Delete(int id);

        BookModel Create(BookModel model);
    }
}
