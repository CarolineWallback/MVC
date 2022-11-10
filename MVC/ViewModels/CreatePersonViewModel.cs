using MVC.Models;
using MVC.ViewModels;
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

        private int _idCounter = 3;
        public void CreatePerson(string name, string number, string city)
        {
            _idCounter++;
            Person person = new Person(_idCounter, name, number, city);
            PeopleViewModel.PeopleList.Add(person);
        }

        public static void MockRepository()
        {
            Person person01 = new Person(1, "Hilda", "0756845297", "Gothenburg");
            PeopleViewModel.PeopleList.Add(person01);
            Person person02 = new Person(2, "Berit", "0735648701", "Stockholm");
            PeopleViewModel.PeopleList.Add(person02);
            Person person03 = new Person(3, "Albert", "0765487028", "Karlstad");
            PeopleViewModel.PeopleList.Add(person03);
        }


    }
}
