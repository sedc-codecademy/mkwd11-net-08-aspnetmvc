using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    //[Route("mvc-app/books")]
    //If you uncomment the above line, your routes in the browser will have to be localhost:1111/mvc-app/books/(name of the custom route ONLY)
    public class BookController : Controller
    {
        //localhost:1111/Book/Index
        [Route("Tosho")]
        public IActionResult Index()
        {
            return View();
        }

        //localhost:1111/Book/Empty
        public IActionResult Empty()
        {
            return new EmptyResult();
        }

        //localhost:1111/Book/Redirect
        public IActionResult Redirect()
        {
            //This redirects us to the same controller in the Index endpoint
            return RedirectToAction("Index");
        }

        //localhost:1111/Book/SecondRedirect
        public IActionResult SecondRedirect()
        {
            //This redirects us to the HomeController in the Index endpoint
            return RedirectToAction("Index", "Home");
        }

        //localhost:1111/Json
        [Route("Json")]
        public IActionResult GetJson()
        {
            Book book = new Book()
            {
                Id = 3,
                Title = "Lord of the rings: Return of the King"
            };

            return new JsonResult(book);
        }

        [Route("details/{id?}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Book book = StaticDb.Books.FirstOrDefault(x => x.Id == id);

            if(book == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(book);
        }

    }
}
