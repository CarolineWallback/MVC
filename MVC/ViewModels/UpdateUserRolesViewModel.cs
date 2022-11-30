using Microsoft.AspNetCore.Identity;

namespace MVC.ViewModels
{
    public class UpdateUserRolesViewModel
    {
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
