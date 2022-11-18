using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

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
                PeopleList = _context.People
                .Include(x => x.City.Country)
                .Include(x => x.Languages).ToList(),
            };

            List<Country> countries = _context.Countries.OrderBy(x => x.CountryName).ToList();

            ViewBag.Countries = new SelectList(countries, "CountryId", "CountryName");
            ViewBag.Cities = new SelectList(countries.First().Cities.OrderBy(x => x.CityName), "CityId", "CityName");
            ViewBag.Languages = new MultiSelectList(_context.Languages.OrderBy(x => x.LanguageName), "LanguageId", "LanguageName");
            return View(peopleViewModel);
        }

        [HttpPost]
        public JsonResult GetCitySelectList(string id)
        {
            var countryId = int.Parse(id);
            Country country = _context.Countries.Include(x => x.Cities).FirstOrDefault(x => x.CountryId == countryId);

            List<CityDTO> citites = new();

            foreach (var city in country.Cities.OrderBy(x => x.CityName).ToList())
            {
                CityDTO cityDto = new()
                {
                    CityId = city.CityId,
                    CityName = city.CityName

                };
                citites.Add(cityDto);
            }

            return Json(citites);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel createPerson)
        {
            ModelState.Remove("id");
            ModelState.Remove("City");
            ModelState.Remove("Languages");
            if (ModelState.IsValid)
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

            ViewBag.Cities = new SelectList(_context.Cities, "CityId", "CityName");
            ViewBag.Languages = new MultiSelectList(_context.Languages, "LanguageId", "LanguageName");

            return View("PeopleList", peopleViewModel);
        }

        public IActionResult SortPeople(PeopleViewModel peopleViewModel)
        {
            peopleViewModel.PeopleList = _context.People.Include(x => x.City.Country).Include(x => x.Languages).ToList();
            peopleViewModel.PeopleList.Sort((x, y) => string.Compare(x.Name, y.Name));

            ViewBag.Cities = new SelectList(_context.Cities, "CityId", "CityName");
            ViewBag.Languages = new MultiSelectList(_context.Languages, "LanguageId", "LanguageName");
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
            
            CreatePersonViewModel createPerson = new()
            {
                Id = person.Id,
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                CityId = person.CityId,
                LanguageIds = languageIds
            };

            ViewBag.Cities = new SelectList(_context.Cities, "CityId", "CityName");
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
