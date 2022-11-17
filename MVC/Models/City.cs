using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List <Person>? People { get; set; } = new List<Person> ();
        public Country? Country { get; set; }
        public int? CountryId { get; set; }
 
    }
}
