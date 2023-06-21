using Microsoft.AspNetCore.Mvc;
using NewsPortalWebApp.Database;

namespace NewsPortalWebApp.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            var allNews = StaticDb.PortalNews;
            return View();
        }

        public IActionResult GetNewsById(int id)
        {
            var news = StaticDb.PortalNews.FirstOrDefault(x => x.Id == id);
            return View(news);
        }

        [Route("[Controller]/[Action]/{searchCriteria?}")]
        public IActionResult SearchNews(string searchCriteria)
        {
            var searchedNews = StaticDb.PortalNews.Where(x => x.Title.Contains(searchCriteria) || x.Text.Contains(searchCriteria)).ToList();
            return View(searchedNews);
        }
    }
}
