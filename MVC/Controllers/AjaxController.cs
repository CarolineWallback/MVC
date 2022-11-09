using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using MVC.Models;

namespace MVC.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            if (CreatePersonViewModel.GetPeopleList().Count == 0)
                CreatePersonViewModel.MockRepository();

            return View();
        }

        public IActionResult ShowPeopleList()
        {
            PeopleViewModel peopleViewModel = new();
            peopleViewModel.PeopleList = CreatePersonViewModel.GetPeopleList();
            
            return PartialView("_personListPartial", peopleViewModel);
        }
        [HttpPost]
        public IActionResult GetDetails(int id)
        {
            
            Person person = CreatePersonViewModel.GetPersonFromId(id);
            if (person == null)
                ViewBag.SearchResult = $"No person with id {id}.";
            return PartialView("_personDetailsPartial", person);
        }

        public IActionResult DeletePerson(int id)
         {
            Person person = CreatePersonViewModel.GetPersonFromId(id);
            CreatePersonViewModel.DeletePerson(person);

            return RedirectToAction("ShowPeopleList");
        }

    }
}
