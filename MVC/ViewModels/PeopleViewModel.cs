using MVC.Models;

namespace MVC.ViewModels
{
    public class PeopleViewModel : CreatePersonViewModel
    {
        public string? Search { get; set; }
        public bool CaseSensitive { get; set; }
        public List <Person> PeopleList { get; set; } = new List<Person>();

    }
}
