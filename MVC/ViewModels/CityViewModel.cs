using MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class CityViewModel
    {
        public List<City> Cities = new List<City>();

        [Display(Name = "City")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Country")]
        public Country? Country { get; set; }

        public int? CountryId { get; set; }
    }
}
