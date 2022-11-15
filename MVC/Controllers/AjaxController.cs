using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AjaxController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowPeopleList()
        {
            PeopleViewModel peopleViewModel = new()
            {
                PeopleList = _context.People.ToList()
            };

            return PartialView("_personListPartial", peopleViewModel);
        }

        [HttpPost]
        public IActionResult GetDetails(string id)
        {
            Person personFromId = _context.People.Include(x => x.City).FirstOrDefault(p => p.Id == id);
            if (personFromId == null)
                ViewBag.SearchResult = $"No person with id {id}.";
            return PartialView("_personDetailsPartial", personFromId);
        }


        public IActionResult DeletePerson(string id)
        {
            Person personFromId = _context.People.Include(x => x.City).FirstOrDefault(p => p.Id == id);
            if (personFromId != null)
            {
                _context.People.Remove(personFromId);
                _context.SaveChanges();
            }

            PeopleViewModel peopleViewModel = new()
            {
                PeopleList = _context.People.Include(x => x.City).ToList()
            };

            return PartialView("_personListPartial", peopleViewModel);
        }
    }
}
