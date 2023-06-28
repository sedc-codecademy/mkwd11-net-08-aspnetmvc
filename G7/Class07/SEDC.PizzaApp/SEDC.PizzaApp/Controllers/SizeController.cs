using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Helpers;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Storage;

namespace SEDC.PizzaApp.Controllers
{
    public class SizeController : Controller
    {
        public IActionResult Index()
        {
            //Using the Custom Mapper we get a List of SizeViewModels
            var sizes = PizzaDb.Sizes.Select(x => x.ToViewModel()).OrderBy(x => x.Name).ToList();

            return View(sizes);
        }

        public IActionResult Details(int id)
        {
            //Get the Size with the matching id
            var size = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

            //Handle scenario where there is no such Size
            if(size == null)
            {
                throw new Exception("Size with Id {id} not found");
            }

            //Directrly transform the Domain Model to a SizeViewModel using the Custom Mapper
            return View(size.ToViewModel());
        }

        public IActionResult CreateEditSize (int? id)
        {
            //If we dont have an id we are creating a new Size and the 
            //model will stay without data
            var model = new SizeViewModel();

            //This handles the Edit
            if(id.HasValue)
            {
                var domainModel = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

                if(domainModel == null)
                {
                    throw new Exception($"Size with id {id} does not exist");

                    //To Do: Fix Behaviour
                    //return RedirectToAction("Index");
                }

                //Change the empty model with a filled in one
                model = domainModel.ToViewModel();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Save(SizeViewModel model)
        {
            //This is MVC Validation with the help of Data Anotations in the corresponding model
            //THis handles if the validation passess
            if (ModelState.IsValid)
            {
                //Cant have more than one Size with the same name
                if (PizzaDb.Sizes.Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
                {
                    throw new Exception("Error");
                }

                //The ID is 0 only when we are Creating a new Size
                if (model.Id == 0)
                {
                    //Use the Custom Mapper for ViewModel -> DomainModel
                    var size = model.ToDomainModel(CommonHelper.GetRandomId());

                    PizzaDb.Sizes.Add(size);

                    return RedirectToAction("Index");
                }

                //This part handles the Edit
                var existingSize = PizzaDb.Sizes.FirstOrDefault(x => x.Id == model.Id);

                if(existingSize == null)
                {
                    throw new Exception($"Size with id {model.Id} does not exist");
                }

                //Case 1
                //PizzaDb.Sizes.Remove(existingSize);
                //var newSize = model.ToDomainModel();           
                //PizzaDb.Sizes.Add(newSize);

                //Case 2
                //PizzaDb.Sizes.Remove(existingSize);
                //existingSize.Name = model.Name;
                //existingSize.Description = model.Description;
                //PizzaDb.Sizes.Add(existingSize);

                existingSize.Name = model.Name;
                existingSize.Description = model.Description;

                return RedirectToAction("Index");
            }
           
            //This handles the case when the validation check does not pass
            return View("CreateEditSize", model);

            // It works the same, need to reaserche
            //return View("CreateEditSize");
        }


        public IActionResult Remove(int id)
        {
            var existingSize = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

            if(existingSize == null)
            {
                throw new Exception($"Size with id {id} does not exist");
            }

            PizzaDb.Sizes.Remove(existingSize);

            return RedirectToAction("Index");
        }
    }
}
