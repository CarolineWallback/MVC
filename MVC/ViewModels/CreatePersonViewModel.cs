using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "City of Residence")]
        public City City { get; set; }

        public int CityId { get; set; }


    }
}
