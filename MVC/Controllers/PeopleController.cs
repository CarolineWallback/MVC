using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult PeopleList()
        {
            PeopleViewModel peopleViewModel = new();
            peopleViewModel.TempList = _context.People.ToList();

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel cpvm)
        {
            PeopleViewModel peopleViewModel = new();
            if(ModelState.IsValid)
            {
                Person person = cpvm.CreatePerson(cpvm.Name, cpvm.PhoneNumber, cpvm.City);
                _context.People.Add(person);
                _context.SaveChanges();
            }
            peopleViewModel.TempList = _context.People.ToList();
            return View("PeopleList", peopleViewModel);
        }


        public IActionResult DeletePerson(string id)
        {
            Person personFromId = _context.People.FirstOrDefault(p => p.Id == id);
            if(personFromId != null)
            {
                _context.People.Remove(personFromId);
                _context.SaveChanges();
            }

            return RedirectToAction("PeopleList");
        }

        
        public IActionResult Search(PeopleViewModel peopleViewModel)
        {
            if(peopleViewModel.Search != null)
            {
                var search = peopleViewModel.Search;

              
                foreach(var person in _context.People.ToList())
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
            peopleViewModel.TempList = _context.People.ToList();
            peopleViewModel.TempList.Sort((x, y) => string.Compare(x.Name, y.Name));

            return View("PeopleList", peopleViewModel);
        }
    }
}
