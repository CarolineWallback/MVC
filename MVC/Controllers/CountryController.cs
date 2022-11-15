using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult CountryList()
        {
            CountryViewModel countryViewModel = new CountryViewModel()
            {
                Countries = _context.Countries.ToList()
            };

            return View(countryViewModel);
        }

        [HttpPost]
        public IActionResult CreateCountry(CountryViewModel countryViewModel)
        {
            if (ModelState.IsValid)
            {
                Country country = new Country()
                {
                    CountryName = countryViewModel.Name,
                };
                _context.Countries.Add(country);
                _context.SaveChanges();
            }

            return RedirectToAction("CountryList");
        }
    }
}
