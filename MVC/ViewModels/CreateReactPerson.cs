using MVC.Models;

namespace MVC.ViewModels
{
    public class CreateReactPerson
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? number { get; set; }
        public int? cityId { get; set; }
        public List <string>? languages { get; set; }
        public List<int>? languageIds { get; set; }
        public List <ReactLanguage>? languageModels { get; set; }
        
    }
}
