﻿using Microsoft.AspNetCore.Identity;

namespace MVC.ViewModels
{
    public class EditRoleMembers
    {
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[] AddIds { get; set; }

        public string[] DeleteIds { get; set; }
    }
}
