using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Person
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public string CityId { get; set; }

        public Person() 
        {

        }
        public Person(string Id, string Name, string PhoneNumber, string CityId)
        {
            this.Id = Id;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.CityId = CityId;

        }
    }
}
