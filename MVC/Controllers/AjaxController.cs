using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using MVC.Models;

namespace MVC.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            if (PeopleViewModel.PeopleList.Count == 0)
                CreatePersonViewModel.MockRepository();

            return View();
        }

        public IActionResult ShowPeopleList()
        {
            PeopleViewModel peopleViewModel = new();
            peopleViewModel.TempList = PeopleViewModel.PeopleList;
            
            return PartialView("_personListPartial", peopleViewModel);
        }
        [HttpPost]
        public IActionResult GetDetails(int id)
        {

            Person personFromId = PeopleViewModel.PeopleList.FirstOrDefault(p => p.Id == id);
            if (personFromId == null)
                ViewBag.SearchResult = $"No person with id {id}.";
            return PartialView("_personDetailsPartial", personFromId);
        }

        public IActionResult DeletePerson(int id)
         {
            Person personFromId = PeopleViewModel.PeopleList.FirstOrDefault(p => p.Id == id);
            PeopleViewModel.PeopleList.Remove(personFromId);

            return RedirectToAction("ShowPeopleList");
        }

    }
}
