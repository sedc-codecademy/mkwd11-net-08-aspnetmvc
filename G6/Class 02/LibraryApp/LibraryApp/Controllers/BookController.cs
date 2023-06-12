using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        //We can hit this method via the following routes:
        //http://localhost:[port]/Book -> Book = controller, Index is default for action
        //http://localhost:[port]/Book/Index -> Book = controller, Index = action
        //We never use Controller in the route, just the part before Controller in the controller's name
        public IActionResult Index()
        {
            return View();
        }

        //http://localhost:[port]/Book/BookDetails
        public IActionResult BookDetails()
        {
            //for each view we must have a view named liked the method, Details here for example
            //we must have a subfolder in the Views folder that is named like the controller (Book)
            return View();
        }

        //http://localhost:[port]/Book/Redirect
        public IActionResult Redirect()
        {
            //...logic...
            //redirect to Index method from the same controller
            return RedirectToAction("Index");
        }

        //http://localhost:[port]/Book/SecondRedirect
        public IActionResult SecondRedirect()
        {
            //...logic...

            //redirect to Index method from HomeController
            return RedirectToAction("Index", "Home");
        }

        //http://localhost:[port]/GetJson
        [Route("GetJson")]
        public IActionResult BookAsJson()
        {
            Book book = new Book
            {
                Id = 1,
                Title = "Our Book",
                Author = "SEDC"
            };

            //serialization
            return new JsonResult(book);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Book bookDb = StaticDb.Books.FirstOrDefault(x => x.Id == id);
            if (bookDb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(bookDb);
        }

        public IActionResult Empty()
        {
            return new EmptyResult();
        }
    }
}
