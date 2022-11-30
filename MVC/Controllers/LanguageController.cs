using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;
using System.Data;

namespace MVC.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult LanguageList()
        {
            LanguageViewModel languageViewModel = new()
            {
                Languages = _context.Languages.ToList()
            };

            return View(languageViewModel);
        }

        [HttpPost]
        public IActionResult CreateLanguage(LanguageViewModel languageViewModel)
        {
            if (ModelState.IsValid)
            {
                Language language = new()
                {
                    LanguageName = languageViewModel.Name,
                };
                _context.Languages.Add(language);
                _context.SaveChanges();
            }

            return RedirectToAction("LanguageList");
        }

        public IActionResult DeleteLanguage(int id)
        {
            Language languageFromId = _context.Languages.FirstOrDefault(x => x.LanguageId == id);
            if (languageFromId != null)
            {
                _context.Languages.Remove(languageFromId);
                _context.SaveChanges();
            }

            return RedirectToAction("LanguageList");
        }

        public IActionResult ViewPeopleWithLanguage(int id)
        {
            Language language = _context.Languages.Find(id);
            PeopleViewModel peopleViewModel = new()
            {
                PeopleList = _context.People
                .Include(x => x.City.Country)
                .Include(x => x.Languages)
                .Where(x => x.Languages.Contains(language)).ToList()
            };

            ViewBag.LanguageName = language.LanguageName;
            
            return View(peopleViewModel);
        }


    }
}
