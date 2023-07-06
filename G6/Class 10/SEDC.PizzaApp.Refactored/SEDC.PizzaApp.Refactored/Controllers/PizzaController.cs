using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    //Scaffolded
    public class PizzaController : Controller
    {
        // GET: PizzaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
