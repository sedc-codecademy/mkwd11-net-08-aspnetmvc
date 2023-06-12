using DataAccess;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Models;

namespace NewsWebApp.Controllers
{
    //NameController/NameAction
    //[Controller]/[Action]
    [Route("st/[Controller]")]
    public class NewsController : Controller
    {
        private readonly IDatabase<News> _newsDatabase;

        public NewsController()
        {
            _newsDatabase = new Database<News>();
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult Index()
        {
            var allNews = _newsDatabase.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var news = _newsDatabase.GetById(id);
            return View();
        }

        public IActionResult RedirectActionDifferentController()
        {
            //return new RedirectResult("https://www.facebook.com");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RedirectActionSameController()
        {
            return RedirectToAction("Index");
        }

        
        public IActionResult EmptyAction()
        {
            return new EmptyResult();
        }

        [Route("json-action")]
        public IActionResult JsonAction()
        {
            var news = new News
            {
                Author = "Risto",
                Text = "Some text here...",
                Title = "My first news"
            };

            return new JsonResult(news);
        }

        //[HttpPost]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPut]
        //public IActionResult Update()
        //{
        //    return View();
        //}

        //[HttpDelete]
        //public IActionResult Delete()
        //{
        //    return View();
        //}
    }
}
