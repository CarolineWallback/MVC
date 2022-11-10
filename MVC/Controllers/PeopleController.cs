using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult PeopleList()
        {
            if (CreatePersonViewModel.GetPeopleList().Count == 0)
                CreatePersonViewModel.MockRepository();

            PeopleViewModel peopleViewModel = new();
            peopleViewModel.PeopleList = CreatePersonViewModel.GetPeopleList();

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel cpvm)
        {
            PeopleViewModel peopleViewModel = new();
            if(ModelState.IsValid)
            {
                peopleViewModel.CreatePerson(cpvm.Name, cpvm.PhoneNumber, cpvm.City);

            }
            peopleViewModel.PeopleList = CreatePersonViewModel.GetPeopleList();
            return View("PeopleList", peopleViewModel);
        }


        public IActionResult DeletePerson(int id)
        {
          
            Person person = CreatePersonViewModel.GetPersonFromId(id);
            CreatePersonViewModel.DeletePerson(person);

            return RedirectToAction("PeopleList");
        }

        
        public IActionResult Search(PeopleViewModel peopleViewModel)
        {
            if(peopleViewModel.Search != null)
            {
                var search = peopleViewModel.Search;
              
                foreach(var person in CreatePersonViewModel.GetPeopleList())
                {
                    if(!peopleViewModel.CaseSensitive)
                    {
                        if (person.Name.Contains(search)||person.City.Contains(search))
                        {
                            peopleViewModel.PeopleList.Add(person);
                        }
                    }
                    else
                    {
                        if(person.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        person.City.Contains(search, StringComparison.OrdinalIgnoreCase))
                        {
                            peopleViewModel.PeopleList.Add(person);
                        }
                    } 
                }
                
            }

            ViewBag.Message = $"Showing {peopleViewModel.PeopleList.Count} result(s).";

            return View("PeopleList", peopleViewModel);
        }

        public IActionResult SortPeople(PeopleViewModel peopleViewModel)
        {
            var people = CreatePersonViewModel.GetPeopleList();
            people.Sort((x, y) => string.Compare(x.Name, y.Name));

            return RedirectToAction("PeopleList", peopleViewModel);
        }
    }
}
