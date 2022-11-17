using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult CityList()
        {
            CityViewModel cityViewModel = new CityViewModel
            {
                Cities = _context.Cities.Include(x => x.Country).ToList()
            };

            ViewBag.Countries = new SelectList(_context.Countries, "CountryId", "CountryName");

            return View(cityViewModel);
        }

        [HttpPost]
        public IActionResult CreateCity(CityViewModel cityViewModel)
        {
            ModelState.Remove("Country");
            if (ModelState.IsValid)
            {
                var country = _context.Countries.Find(cityViewModel.CountryId);
                City city = new City()
                {
                    CityName = cityViewModel.Name,
                    CountryId = cityViewModel.CountryId,
                    Country = country
                };

                _context.Cities.Add(city);
                _context.SaveChanges();
            }

            return RedirectToAction("CityList");
        }

    public IActionResult DeleteCity(int id)
        {
            City cityFromId = _context.Cities.Include(x => x.People).FirstOrDefault(x => x.CityId == id);
            if (cityFromId != null)
            {
                _context.Cities.Remove(cityFromId);
                _context.SaveChanges();
            }

            return RedirectToAction("CityList");
        }

        public IActionResult ViewCitizens(int id)
        {
            PeopleViewModel peopleViewModel = new();
            peopleViewModel.PeopleList = _context.People.Include(x => x.City.Country).Include(x => x.Languages).Where(x => x.CityId == id).ToList();

            return View(peopleViewModel);
        }
    }
}
