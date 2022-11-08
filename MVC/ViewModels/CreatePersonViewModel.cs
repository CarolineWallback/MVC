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

        private int _idCounter = 0;

        public List<Person> GetPeopleList()
        {
            return PeopleList;
        }

        public void CreatePerson(string name, string number, string city)
        {
            var id = _idCounter++;
            Person person = new Person(id, name, number, city);
            PeopleList.Add(person);

        }

        public bool DeletePerson(Person person)
        { 

            return PeopleList.Remove(person);
        }

        public Person GetPersonFromId(int id)
        {
            Person personFromId = PeopleList.Find(p => p.Id == id);
            return personFromId;
        }

    }
}
