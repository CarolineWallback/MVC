using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class CreatePersonViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "City of Residence")]
        [Required]
        public City City { get; set; }

        public int CityId { get; set; }

        [Display(Name = "Languages")]
        [Required]
        public List<Language> Languages { get; set; } 
        public List<int> LanguageIds { get; set; } 



    }
}
