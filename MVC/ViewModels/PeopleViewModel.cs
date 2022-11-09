using MVC.Models;

namespace MVC.ViewModels
{
    public class PeopleViewModel : CreatePersonViewModel
    {
        public List<Person> PeopleList { get; set; } = new List<Person>();
        public string Search { get; set; } 
        public bool CaseSensitive { get; set; }

    }
}
