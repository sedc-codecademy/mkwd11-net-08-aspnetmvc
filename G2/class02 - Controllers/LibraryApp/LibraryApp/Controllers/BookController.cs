using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        //https://localhost:7100/book/index
        public IActionResult Index()
        {
            return View();
        }

        //https://localhost:7100/book/empty
        public IActionResult Empty()
        {
            return new EmptyResult();
        }

        //https://localhost:7100/json
        [Route("json")]
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

    }
}
