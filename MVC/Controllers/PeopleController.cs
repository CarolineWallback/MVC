using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult PeopleList()
        {
            if (PeopleViewModel.PeopleList.Count == 0)
                CreatePersonViewModel.MockRepository();

            PeopleViewModel peopleViewModel = new();
            peopleViewModel.TempList = PeopleViewModel.PeopleList;

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
            peopleViewModel.TempList = PeopleViewModel.PeopleList;
            return View("PeopleList", peopleViewModel);
        }


        public IActionResult DeletePerson(int id)
        {
            Person personFromId = PeopleViewModel.PeopleList.FirstOrDefault(p => p.Id == id);
            PeopleViewModel.PeopleList.Remove(personFromId);

            return RedirectToAction("PeopleList");
        }

        
        public IActionResult Search(PeopleViewModel peopleViewModel)
        {
            if(peopleViewModel.Search != null)
            {
                var search = peopleViewModel.Search;

              
                foreach(var person in PeopleViewModel.PeopleList)
                {
                    if(!peopleViewModel.CaseSensitive)
                    {
                        if (person.Name.Contains(search)||person.City.Contains(search))
                        {
                            peopleViewModel.TempList.Add(person);
                        }
                    }
                    else
                    {
                        if(person.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        person.City.Contains(search, StringComparison.OrdinalIgnoreCase))
                        {
                            peopleViewModel.TempList.Add(person);
                        }
                    } 
                }
                
            }

            ViewBag.Message = $"Showing {peopleViewModel.TempList.Count} result(s).";

            return View("PeopleList", peopleViewModel);
        }

        public IActionResult SortPeople(PeopleViewModel peopleViewModel)
        {
            var people = PeopleViewModel.PeopleList;
            people.Sort((x, y) => string.Compare(x.Name, y.Name));

            return RedirectToAction("PeopleList", peopleViewModel);
        }
    }
}
