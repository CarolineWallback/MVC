using MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class CountryViewModel
    {
        public List<Country> Countries = new List<Country>();

        [Display(Name = "Country")]
        [Required]
        public string Name { get; set; }
    }
}
