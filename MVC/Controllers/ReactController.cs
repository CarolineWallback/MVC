using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;
using Newtonsoft.Json;
using System;
using System.Text.Json.Nodes;

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPeople()
        {
            return await _context.People.ToListAsync();
        }

        //[Route("api/[controller]/Details")]
        [HttpGet("{id}")]
        public async Task<ReactPerson> GetPersonDetails(string id)
        {
            Person person = await _context.People.Include(x => x.City).Include(x => x.Languages).FirstOrDefaultAsync(x => x.Id == id);
            City cityFromId = await _context.Cities.FirstOrDefaultAsync(x => x.CityId == person.CityId);
            List<string> languages = new();
            foreach (var language in person.Languages)
            {
                languages.Add(language.LanguageName);
            }

            ReactPerson reactPerson = new();

            if (cityFromId != null)
            {
                reactPerson.City = cityFromId.CityName;
                reactPerson.Country = _context.Countries.FirstOrDefault(x => x.CountryId == cityFromId.CountryId).CountryName;
            }

            reactPerson.Languages = languages;


            return reactPerson;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Person personFromId = _context.People.FirstOrDefault(p => p.Id == id);
            if (personFromId != null)
            {
                _context.People.Remove(personFromId);
                _context.SaveChanges();

                return StatusCode(202);
            }
            return StatusCode(404);
        }

        [HttpPost("create")]
        public IActionResult Create(JsonObject person)
        {
            try
            {
                string jsonPerson = person.ToString();
                CreateReactPerson create = JsonConvert.DeserializeObject<CreateReactPerson>(jsonPerson);

                Person newPerson = new()
                {
                    Name = create.name,
                    PhoneNumber = create.number,
                };

                if(create.city != null)
                {
                    newPerson.CityId = create.city;
                    newPerson.City = _context.Cities.FirstOrDefault(x => x.CityId == create.city);
                }
                if (create.languages.Count > 0)
                    newPerson.Languages = _context.Languages.Where(x => create.languages.Contains(x.LanguageId)).ToList();

                _context.People.Add(newPerson);
                    _context.SaveChanges();
                    return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }
            
        }

        [HttpGet("countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        [HttpGet("cities/{id}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities(int id)
        {
            List<City> cities = await _context.Cities.Where(x => x.CountryId == id).ToListAsync();

            return cities;
        }

        [HttpGet("languages")]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

    }
}
