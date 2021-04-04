using Microsoft.AspNetCore.Identity;
using SAAS_Deployment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.ViewModel
{
    public class ApplicationUserRole
    {
        public ApplicationUser User { get; set; }

        public IEnumerable<string> UserRoles { get; set; }

        public ApplicationUserRole(ApplicationUser user, IEnumerable<string> roles)
        {
            this.User = user;
            this.UserRoles = roles;
        }
    }
}
