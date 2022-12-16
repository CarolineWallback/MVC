namespace MVC.Models
{
    public class ReactPerson
    {
        public string City { get; set; }
        public string Country { get; set; }
        public int? CountryId { get; set; }
        public List<string> Languages { get; set; }
        public List<int> LanguageIds { get; set; }
        public List <ReactLanguage> LanguageModels { get; set; } = new List<ReactLanguage>();
    }
}
