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

        [HttpGet("{id}")]
        public async Task<ReactPerson> GetPersonDetails(string id)
        {
            Person person = await _context.People.Include(x => x.City).Include(x => x.Languages).FirstOrDefaultAsync(x => x.Id == id);
            City cityFromId = await _context.Cities.FirstOrDefaultAsync(x => x.CityId == person.CityId);
            List<string> languages = new();
            List<int> languageIds = new();
            foreach (var language in person.Languages)
            {
                languages.Add(language.LanguageName);
                languageIds.Add(language.LanguageId);
            }

           
            ReactPerson reactPerson = new();

            if (cityFromId != null)
            {
                reactPerson.City = cityFromId.CityName;
                reactPerson.Country = _context.Countries.FirstOrDefault(x => x.CountryId == cityFromId.CountryId).CountryName;
                reactPerson.CountryId = cityFromId.CountryId;
            }

            reactPerson.Languages = languages;
            reactPerson.LanguageIds = languageIds;
            reactPerson.LanguageModels = new List<ReactLanguage>();
            foreach(var language in person.Languages)
            {
                ReactLanguage reactLanguage = new ReactLanguage()
                {
                    LanguageId = language.LanguageId,
                    LanguageName = language.LanguageName
                };

                reactPerson.LanguageModels.Add(reactLanguage);
            }
           
            


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
            return StatusCode(500);
        }

        [HttpPost("create")]
        public async Task <IActionResult> Create(JsonObject person)
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

                if (create.cityId != null)
                {
                    newPerson.City = await _context.Cities.FirstOrDefaultAsync(x => x.CityId == create.cityId);
                }

                newPerson.Languages = await _context.Languages.Where(x => create.languages.Contains(x.LanguageName)).ToListAsync();

                await _context.People.AddAsync(newPerson);
                _context.SaveChanges();
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPut]
        public async Task <IActionResult> UpdatePerson (JsonObject person)
        {
            try
            {
                string jsonPerson = person.ToString();
                CreateReactPerson createPerson = JsonConvert.DeserializeObject<CreateReactPerson>(jsonPerson);

                var city = await _context.Cities.FindAsync(createPerson.cityId);
                List<Language> languages = new();
                foreach (var language in createPerson.languageModels)
                {
                    languages.Add(await _context.Languages.FirstOrDefaultAsync(x => x.LanguageId == language.LanguageId));
                }
                
                Person personById = await _context.People.Include(x => x.City).Include(x => x.Languages).FirstOrDefaultAsync(x => x.Id == createPerson.id);
                if (personById != null)
                {
                    personById.Name = createPerson.name;
                    personById.PhoneNumber = createPerson.number;
                    personById.Languages = languages;

                    if (city != null)
                    {
                        personById.City = city;
                    }
                   
                    await _context.SaveChangesAsync();
                    return StatusCode(201);

                }

                return StatusCode(500);

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
        public async Task<ActionResult<IEnumerable<City>>> GetCitiesInCountry(int id)
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
