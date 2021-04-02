using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class Employee: ApplicationUser
    {

        [Required]
        public DateTime DateJoined { get; set; }
        
        [Required]
        public string EmerContact { get; set; }

    }
}
