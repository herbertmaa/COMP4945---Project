using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class ApplicationUser: IdentityUser

    {
        public string Branch { get; set; }

        public string Address { get; set; }



    }

}
