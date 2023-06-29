using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pazar4.BLL.Models;
using Pazar4.BLL.Services;

namespace Pazar4.Web.Controllers
{
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;

        public SellerController(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }
        // GET: SellerController
        public ActionResult Index(int page = 0, int size = 10, string search = "")
        {
            var models = sellerService.GetSellers(page, size);
            return View(models);
        }

        // GET: SellerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SellerController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: SellerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterSellerModel model)
        {
            try
            {
                var result = await sellerService.Register(model);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: SellerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SellerController/Edit/5
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

        // GET: SellerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SellerController/Delete/5
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
