using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet] - the defualt is a GET 
        public IActionResult Empty()
        {
            return new EmptyResult();
        }


        public IActionResult Redirect()
        {
            //call the action Index from the same Controller(Book)
            return RedirectToAction("Index");
        }

        public IActionResult InvalidRedirect()
        {
            //invalid redirect, will result with an error
            //we must specify the action to which we are redirecting
            return RedirectToAction();
        }

        public IActionResult RedirectToHomeController()
        {
            //call the Index action from HomeController
            //first param is the action name, the second param is the controller name
            return RedirectToAction("Privacy", "Home");
        }

        [Route("Json")]
        public IActionResult GetJson()
        {
            Book book = new Book()
            {
                Id = 1,
                Title = "Kasni porasni"
            };
            return new JsonResult(book);
        }

        public IActionResult Details(int? id)
        {

            if(id == null)
            {
                return RedirectToAction("Empty");
            }

            Book book = StaticDb.Books.Where(x => x.Id == id).FirstOrDefault();

            if(book == null)
            {
                return RedirectToAction("Empty");
            }

            return View(book);
        }

        [Route("DeleteBook/{id?}")]
        public IActionResult Delete(int? id)
        {
            return View();
        }
    }
}
