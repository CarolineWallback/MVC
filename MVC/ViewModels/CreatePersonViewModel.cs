using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class CreatePersonViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Country")]
        public Country? Country { get; set; }
        public int? CountryId { get; set; }

        [Display(Name = "City of Residence")]
        public City? City { get; set; }

        public int? CityId { get; set; }

        [Display(Name = "Languages")]
        [Required]
        public List<Language>? Languages { get; set; } 
        public List<int>? LanguageIds { get; set; } 



    }
}
