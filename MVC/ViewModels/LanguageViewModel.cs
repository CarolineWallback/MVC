using MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class LanguageViewModel
    {
        public List<Language> Languages = new List<Language>();

        [Display(Name = "Language")]
        [Required]
        public string Name { get; set; }
    }
}
