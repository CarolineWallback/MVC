using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Person
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }

        public Person() { }
        public Person(string Id, string Name, string PhoneNumber, string City)
        {
            this.Id = Id;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.City = City;
        }
    }
}
