using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            PeopleViewModel peopleViewModel = new()
            {
                PeopleList = _context.People.Include(x => x.City).ToList(),
            };

            ViewBag.Cities = new SelectList(_context.Cities, "CityId", "CityName");
            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel createPerson)
        {
            ModelState.Remove("City");
            if (ModelState.IsValid)
            {
                Person person = new Person(createPerson.Name, createPerson.PhoneNumber, createPerson.CityId);
                _context.People.Add(person);
                _context.SaveChanges();
            }
            
            return RedirectToAction("PeopleList");
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
            if (!String.IsNullOrEmpty(peopleViewModel.Search))
            {
                var search = peopleViewModel.Search;


                foreach (var person in _context.People.Include(x => x.City).ToList())
                {
                    if (!peopleViewModel.CaseSensitive)
                    {
                        if (person.Name.Contains(search) || person.City.CityName.Contains(search))
                        {
                            peopleViewModel.PeopleList.Add(person);
                        }
                    }
                    else
                    {
                        if (person.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        person.City.CityName.Contains(search, StringComparison.OrdinalIgnoreCase))
                        {
                            peopleViewModel.PeopleList.Add(person);
                        }
                    }
                }

                ViewBag.Message = $"Showing {peopleViewModel.PeopleList.Count} result(s).";
            }
            else 
                peopleViewModel.PeopleList = _context.People.Include(x => x.City).ToList();

            ViewBag.Cities = new SelectList(_context.Cities, "CityId", "CityName");

            return View("PeopleList", peopleViewModel);
        }

        public IActionResult SortPeople(PeopleViewModel peopleViewModel)
        {
            peopleViewModel.PeopleList = _context.People.Include(x => x.City).ToList();
            peopleViewModel.PeopleList.Sort((x, y) => string.Compare(x.Name, y.Name));

            ViewBag.Cities = new SelectList(_context.Cities, "CityId", "CityName");
            return View("PeopleList", peopleViewModel);
        }
    }
}
