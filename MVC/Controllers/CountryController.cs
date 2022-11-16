﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            CountryViewModel countryViewModel = new()
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
                Country country = new()
                {
                    CountryName = countryViewModel.Name,
                };
                _context.Countries.Add(country);
                _context.SaveChanges();
            }

            return RedirectToAction("CountryList");
        }

        public IActionResult DeleteCountry(int id)
        {
            Country countryFromId = _context.Countries.Include(x => x.Cities).FirstOrDefault(x => x.CountryId == id);
            if (countryFromId != null)
            {
                _context.Countries.Remove(countryFromId);
                _context.SaveChanges();
            }

            return RedirectToAction("CountryList");
        }

        public IActionResult ViewCitiesInCountry(int id)
        {
            CityViewModel cityViewModel = new()
            {
                Cities = _context.Cities.Include(x => x.Country).Where(x => x.CountryId == id).ToList(),
            };

            return View(cityViewModel);
        }
    }
}