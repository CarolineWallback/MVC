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
        [Required]
        public string City { get; set; }

        public Person CreatePerson(string name, string number, string city)
        {
            var id = Guid.NewGuid().ToString();
            Person person = new Person(id, name, number, city);
            return person;
        }

    }
}
