using Books.BLL.Models;
using Books.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BLL.Mappers
{
    public static class BooksMapper
    {
        public static BookModel ToModel(this Book book)
        {
            return new BookModel
            {
                Author = book.Author,
                Id = book.Id,
                Name = book.Name
            };
        }
    }
}
