using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class ApplicationUser: IdentityUser
    {
        public Branch Branch { get; set; }
    }
}
