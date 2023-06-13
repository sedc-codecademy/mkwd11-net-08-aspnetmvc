using DemoWebApp.Db;
using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            //List<GameViewModel> allGames = GamesDb.Games;
            //return View(allGames);


            //ViewBag.AllGames = allGames;
            //ViewBag.Numbers = new List<int> { 1, 2, 3 };
            //return View();

            //ViewData["AllGames"] = allGames;
            //Key: AllGames, Value: allGames
            //return View();

            List<GameViewModel> allGames = GamesDb.Games;
            return View(allGames);
        }

        public IActionResult Details(int id)
        {
            GameViewModel game = GamesDb.Games.FirstOrDefault(x => x.Id == id);
            return View(game);
        }
    }
}
