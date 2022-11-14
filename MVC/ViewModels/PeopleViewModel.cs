using MVC.Models;

namespace MVC.ViewModels
{
    public class PeopleViewModel : CreatePersonViewModel
    {
        //public static List<Person> PeopleList { get; set; } = new List<Person>();
        public string Search { get; set; } 
        public bool CaseSensitive { get; set; }
        public List <Person> TempList { get; set; } = new List<Person>();

    }
}
