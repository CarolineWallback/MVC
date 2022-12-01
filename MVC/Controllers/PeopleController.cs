using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;
using System.Data;

namespace MVC.Controllers
{
    [Authorize(Roles = "User, Moderator")]
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
                PeopleList = _context.People
                .Include(x => x.City.Country)
                .Include(x => x.Languages).ToList(),
            };

            ViewBag.Countries = new SelectList(_context.Countries.OrderBy(x => x.CountryName), "CountryId", "CountryName");
            ViewBag.Languages = new MultiSelectList(_context.Languages.OrderBy(x => x.LanguageName), "LanguageId", "LanguageName");
            return View(peopleViewModel);
        }

        [HttpPost]
        public JsonResult GetCitySelectList(string id)
        {
            if (id == null)
                return Json(null);

            var countryId = int.Parse(id);
            Country country = _context.Countries.Include(x => x.Cities).FirstOrDefault(x => x.CountryId == countryId);

            CreatePersonViewModel createPerson = new()
            {
                cities = (from city in country.Cities.OrderBy(x => x.CityName)
                          select new SelectListItem
                          {
                              Value = city.CityId.ToString(),
                              Text = city.CityName
                          }).ToList()
            };

            return Json(createPerson.cities);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel createPerson)
        {
            ModelState.Remove("id");
            ModelState.Remove("City");
            ModelState.Remove("Languages");
            if (ModelState.IsValid && createPerson.CityId > 0)
            {
                var city = _context.Cities.Find(createPerson.CityId);
                List<Language> languages = new();
                if (createPerson.LanguageIds != null)
                    languages = _context.Languages.Where(x => createPerson.LanguageIds.Contains(x.LanguageId)).ToList();

                Person person = new()
                {
                    Name = createPerson.Name,
                    PhoneNumber = createPerson.PhoneNumber,
                    CityId = createPerson.CityId,
                    City = city,
                    Languages = languages
                };
                   
                _context.People.Add(person);
                _context.SaveChanges();
            }
            
            return RedirectToAction("PeopleList");
        }

        [Authorize(Roles = "Admin, Moderator")]
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


                foreach (var person in _context.People.Include(x => x.City.Country).Include(x => x.Languages).ToList())
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
                peopleViewModel.PeopleList = _context.People.Include(x => x.City.Country).Include(x => x.Languages).ToList();

            ViewBag.Countries = new SelectList(_context.Countries.OrderBy(x => x.CountryName), "CountryId", "CountryName");
            ViewBag.Languages = new MultiSelectList(_context.Languages.OrderBy(x => x.LanguageName), "LanguageId", "LanguageName");

            return View("PeopleList", peopleViewModel);
        }

        public IActionResult SortPeople(PeopleViewModel peopleViewModel)
        {
            peopleViewModel.PeopleList = _context.People.Include(x => x.City.Country).Include(x => x.Languages).ToList();
            peopleViewModel.PeopleList.Sort((x, y) => string.Compare(x.Name, y.Name));

            ViewBag.Countries = new SelectList(_context.Countries.OrderBy(x => x.CountryName), "CountryId", "CountryName");
            ViewBag.Languages = new MultiSelectList(_context.Languages.OrderBy(x => x.LanguageName), "LanguageId", "LanguageName");
            return View("PeopleList", peopleViewModel);
        }

        public IActionResult UpdatePerson(string id)
        {
            Person person = _context.People.Include(x => x.City).Include(x => x.Languages).FirstOrDefault(x => x.Id == id);
            List<int> languageIds = new();
            foreach(var language in person.Languages)
            {
                languageIds.Add(language.LanguageId);
            }
            
            var countries = _context.Countries.Include(x => x.Cities).OrderBy(x => x.CountryName);

            CreatePersonViewModel createPerson = new()
            {
                Id = person.Id,
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                LanguageIds = languageIds
        };

            if (person.City != null)
            {
                createPerson.CityId = person.CityId;
                createPerson.CountryId = person.City.CountryId;
                createPerson.cities = (from city in countries.FirstOrDefault(x => x.CountryId == person.City.CountryId).Cities.OrderBy(x => x.CityName)
                                       select new SelectListItem
                                       {
                                           Value = city.CityId.ToString(),
                                           Text = city.CityName
                                       }).ToList();
            }

            ViewBag.Countries = new SelectList(countries, "CountryId", "CountryName");
            ViewBag.Languages = new MultiSelectList(_context.Languages, "LanguageId", "LanguageName");
            return View(createPerson);
        }

        public IActionResult SavePerson(string id, CreatePersonViewModel createPerson)
        {
            var city = _context.Cities.Find(createPerson.CityId);
            var languages = _context.Languages.Where(x => createPerson.LanguageIds.Contains(x.LanguageId)).ToList();

            Person person = _context.People.Include(x => x.Languages).FirstOrDefault(x => x.Id == id);
          
            person.Name = createPerson.Name;
            person.PhoneNumber = createPerson.PhoneNumber;
            person.City = city;
            person.Languages = languages;

            _context.SaveChanges();

            return RedirectToAction("PeopleList");
        }
    }
}
