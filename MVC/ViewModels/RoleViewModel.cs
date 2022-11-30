using Microsoft.AspNetCore.Identity;

namespace MVC.ViewModels
{
    public class RoleViewModel : EditRoleMembers
    {
        public IdentityRole Role { get; set; }
        public List<ApplicationUser> Members { get; set; } = new();
        public List<ApplicationUser> NonMembers { get; set; } = new();
    }
}
