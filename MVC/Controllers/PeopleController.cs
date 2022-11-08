using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult PeopleList()
        {
            PeopleViewModel peopleViewModel = new();
            CreatePersonViewModel createPersonViewModel = new();
            peopleViewModel.PeopleList = createPersonViewModel.GetPeopleList();

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel cpvm)
        {
            PeopleViewModel peopleViewModel = new();
            peopleViewModel.CreatePerson(cpvm.Name, cpvm.PhoneNumber, cpvm.City);
            peopleViewModel.PeopleList = peopleViewModel.GetPeopleList();
            return View("PeopleList", peopleViewModel);
        }


        public IActionResult DeletePerson(int id)
        {
            CreatePersonViewModel createPersonViewModel = new();
            Person person = createPersonViewModel.GetPersonFromId(id);
            createPersonViewModel.DeletePerson(person);

            return RedirectToAction("PeopleList");
        }

        
        public IActionResult Search(PeopleViewModel peopleViewModel)
        {
            if(peopleViewModel.Search != null)
            {
                var search = peopleViewModel.Search;
                CreatePersonViewModel createPersonViewModel = new();
          
                foreach(var person in createPersonViewModel.GetPeopleList())
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
            CreatePersonViewModel createPersonViewModel = new();
            var people = createPersonViewModel.GetPeopleList();
            people.Sort((x, y) => string.Compare(x.Name, y.Name));

            return RedirectToAction("PeopleList", peopleViewModel);
        }
    }
}
