using MVC.Models;
using MVC.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "City of Residence")]
        public string City { get; set; }

        private static List<Person> PeopleList = new List<Person>();

        private int _idCounter = 3;

        public static List<Person> GetPeopleList()
        {
            return PeopleList;
        }

        public static void MockRepository()
        {
            Person person01 = new Person(1, "Hilda", "0756845297", "Gothenburg");
            PeopleList.Add(person01);
            Person person02 = new Person(2, "Berit", "0735648701", "Stockholm");
            PeopleList.Add(person02);
            Person person03 = new Person(3, "Albert", "0765487028", "Karlstad");
            PeopleList.Add(person03);
        }

        public void CreatePerson(string name, string number, string city)
        {
            _idCounter++;
            Person person = new Person(_idCounter, name, number, city);
            PeopleList.Add(person);
        }

        public static bool DeletePerson(Person person)
        { 
            return PeopleList.Remove(person);
        }

        public static Person GetPersonFromId(int id)
        {
            Person personFromId = PeopleList.FirstOrDefault(p => p.Id == id);
            return personFromId;
        }

    }
}
