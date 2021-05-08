using EShoppingProject.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShoppingProject.Application.Models.DTOs
{
    public class RoleEdit
    {
        public AppRole Role { get; set; }
        public IEnumerable<AppUser> HasRole { get; set; }
        public IEnumerable<AppUser> HasNotRole { get; set; }

        public string RoleName { get; set; }

        public string[] AddIds { get; set; }
        public string[] DeleteIds { get; set; }
    }
}
