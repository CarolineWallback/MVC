using Microsoft.AspNetCore.Identity;

namespace MVC.ViewModels
{
    public class UsersViewModel
    {
        public Dictionary <ApplicationUser, List<string>> applicationUsers { get; set; } = new();     
    }
}
