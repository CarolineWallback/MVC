using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }

        public Person() 
        {

        }
        public Person(string Name, string PhoneNumber, int CityId)
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.CityId = CityId;
        }
    }
}
