using Microsoft.AspNetCore.Identity;

namespace MVC.ViewModels
{
    public class UpdateUserRolesViewModel
    {
        public string UserId { get; set; }
        public IList<string> Roles { get; set; }
    }
}
