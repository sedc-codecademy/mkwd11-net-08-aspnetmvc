using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        //wew don't use Controller in the route, just the part before Controller in the Controller name
        //for example -> BookController -> we use only Book
        //localhost:[port]/Book/Index
        public IActionResult Index()
        {
            //we must have a View in the Views folder, in subfolder which has the Controller's name
            //this means that we must have a Book subfolder in the Views folder

            //we must have a View with the method's name (Index)

            //1. we get the records from the db 
            List<Book> booksDb = StaticDb.Books;
            //2. we send the records to the view, so it can display the data
            return View(booksDb);
        }

        public IActionResult Empty()
        {
            return new EmptyResult();
        }

        public IActionResult Redirect()
        {
            //call the action Index from the same Controller (Book)
            return RedirectToAction("Index");
        }

        public IActionResult SecondRedirect()
        {
            //call the action Index from the HomeController
            //the second param is the name of the Controller, but without Controller suffix
            return RedirectToAction("Index", "Home");
        }

        //localhost:[port]/Json
        [Route("Json")]
        public IActionResult GetJson()
        {
            Book book = new Book()
            {
                Id = 1,
                Title = "Kasni Porasni"
            };

            return new JsonResult(book);
        }

        //localhost:[port]/Book/Details/1 -> id = 1
        //in Program.cs the route contains third part -> id
        public IActionResult Details(int? id)
        {
            //return View(); -> this way we don't send data to the view. It needs a Book object, so it will
            //give NullReference exception, because no Book object is sent

            if(id == null)
            {
                //we can add new Error method that returns a view with a message
                return RedirectToAction("Empty");
            }

            Book book = StaticDb.Books.FirstOrDefault(x => x.Id == id);
            if(book == null)
            {
                //we can add new Error method that returns a view with a message
                return RedirectToAction("Empty");
            }

            //we can send object to the view
            //we send data to the View 
            return View(book);
        }

        [Route("DeleteBook/{id?}")]
        public IActionResult Delete(int? id)
        {
            return View();
        }
    }
}
