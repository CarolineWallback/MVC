using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using MVC.Models;
using MVC.Data;
using Microsoft.EntityFrameworkCore;

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
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.TempList = _context.People.ToList();
            
            return PartialView("_personListPartial", peopleViewModel);
        }

        [HttpPost]
        public IActionResult GetDetails(string id)
        {
            Person personFromId = _context.People.FirstOrDefault(p => p.Id == id);
            if (personFromId == null)
                ViewBag.SearchResult = $"No person with id {id}.";
            return PartialView("_personDetailsPartial", personFromId);
        }


        public IActionResult DeletePerson(string id)
        {
            Person personFromId = _context.People.FirstOrDefault(p => p.Id == id);
            if(personFromId != null)
            {
                _context.People.Remove(personFromId);
                _context.SaveChanges();
            }

            PeopleViewModel peopleViewModel = new();
            peopleViewModel.TempList = _context.People.ToList();

            return PartialView("_personListPartial", peopleViewModel);
        }
    }
}
