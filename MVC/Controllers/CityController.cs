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
                City city = new City()
                {
                    CityName = cityViewModel.Name,
                    CountryId = cityViewModel.CountryId,
                };
                _context.Cities.Add(city);
                _context.SaveChanges();
            }

            return RedirectToAction("CityList");
        }
    }
}
