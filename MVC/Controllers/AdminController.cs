using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.ViewModels;

namespace MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task <IActionResult> UserList()
        {
            var users = _userManager.Users.ToList();
            UsersViewModel usersViewModel = new();

            foreach(var user in users)
            {
                List<string> roles = new(await _userManager.GetRolesAsync(user));
                usersViewModel.applicationUsers.Add(user, roles);
                  
            };

            return View(usersViewModel);
        }
        public IActionResult RoleSettings()
        {
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult CreateApplicationRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicationRole(string name)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(name);
            if(role != null)
            {
                ViewBag.RoleMessage = "There is already a role with that name";
                return RedirectToAction("AddRole");
            }

            var newRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                NormalizedName = name.ToUpper(),

            };
            await _roleManager.CreateAsync(newRole);
            return RedirectToAction("RoleSettings");
        }

        public async Task <IActionResult> DeleteApplicationRole(IdentityRole identityrole)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(identityrole.Id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }

            List<IdentityRole> roles = _roleManager.Roles.ToList();
            return View("RoleSettings", roles);
        }

        public async Task <IActionResult> EditUserRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UpdateUserRolesViewModel updateUser = new UpdateUserRolesViewModel()
            {
                UserId = user.Id,
                Roles = await _userManager.GetRolesAsync(user),
            };

            ViewBag.Roles = new MultiSelectList(_roleManager.Roles, "Id", "Name");
            return View(updateUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRoles(UpdateUserRolesViewModel updateUserRoles)
        {
            var user = await _userManager.FindByIdAsync(updateUserRoles.UserId);
            IList<string> currentRoles = await _userManager.GetRolesAsync(user);
            IList<ApplicationUser> adminList = await _userManager.GetUsersInRoleAsync("Admin");

            if(currentRoles.Contains("Admin") && adminList.Count <= 1 && !updateUserRoles.Roles.Contains("Admin"))
            {
                ViewBag.Admin = "There must be at least one Admin.";
               
                UpdateUserRolesViewModel updateUser = new UpdateUserRolesViewModel()
                {
                    UserId = user.Id,
                    Roles = await _userManager.GetRolesAsync(user),
                };

                ViewBag.Roles = new MultiSelectList(_roleManager.Roles, "Id", "Name");
                return View(updateUser);
            }
            else
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRolesAsync(user, updateUserRoles.Roles);
                return RedirectToAction("UserList");
            }
        }







    }
}
