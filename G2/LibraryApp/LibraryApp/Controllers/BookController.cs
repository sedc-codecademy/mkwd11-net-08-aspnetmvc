using LibraryApp.Models;
using LibraryApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        //https://localhost:7100/book/index
        public IActionResult Index()
        {
            List<Book> books = StaticDb.Books;

            return View(books);
        }

        //https://localhost:7100/book/empty
        public IActionResult Empty()
        {
            return new EmptyResult();
        }

        //https://localhost:7100/json
        [HttpGet]
        [Route("json")]
        //[HttpGet("json")]
        public IActionResult GetJson()
        {
            Book book = new Book()
            {
                Id = 1,
                Title = "Kasni Porasni"
            };

            return new JsonResult(book);
        }

        //https://localhost:7100/book/redirect
        public IActionResult Redirect()
        {
            return RedirectToAction("Index");
        }

        //https://localhost:7100/book/secondredirect
        public IActionResult SecondRedirect()
        {
            return RedirectToAction("Privacy", "Home");
        }

        //https://localhost:7100/book/details/1 => route parameter
        //https://localhost:7100/book/details?id=1 => query parameter
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }

            Book book = StaticDb.Books.FirstOrDefault(book => book.Id == id);

            if (book == null)
            {
                return new EmptyResult();
            }

            return View(book);
        }

        [Route("deletebook/{id?}/filter/{filterParam?}")]
        public IActionResult Delete(int? id, string? filterParam)
        {
            return View();
        }

        //View Data
        public IActionResult ViewDataExample()
        {
            ViewData.Add("randomData", "some random view data");

            var book = new Book
            {
                Id = 123,
                Title = "Test Book 1"
            };

            //not wirking in view data
            ViewData.Add("book", book);

            return View();
        }

        //View Bag
        public IActionResult ViewBagExample() 
        {
            ViewBag.RandomData = "some random view bag data";

            var book = new Book
            {
                Id = 123,
                Title = "Test Book 1"
            };

            ViewBag.Book = book;

            return View();
        }

        //View Model
        public IActionResult ViewModelExample() 
        {
            var book = new Book
            {
                Id = 123,
                Title = "Test Book 1"
            };

            var comic = new Comic
            {
                Id = 125,
                ComicTitle = "Test Comic 1"
            };

            var viewModel = new BookComicViewModel
            {
                Book = book,
                Comic = comic
            };

            return View(viewModel);
        }


    }
}
