using Books.BLL.Mappers;
using Books.BLL.Models;
using Books.DAL.Entities;
using Books.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BLL.Services
{
    public class BookService
        : IBookService
    {
        private readonly IRepository<Book> repository;

        public BookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }
        public BookModel Create(BookModel model)
        {
            throw new NotImplementedException();
        }

        public BookModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BookModel GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookModel> GetBooks()
        {
            IEnumerable<Book> books = repository.GetAll();
            return books.Select(x => x.ToModel());
        }

        public BookModel Update(BookModel model)
        {
            throw new NotImplementedException();
        }
    }
}
