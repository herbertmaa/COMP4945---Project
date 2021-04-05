﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SAAS_Deployment.Models
{
    public class Employee : Person
    {
        [Required]
        public DateTime DateJoined { get; set; }
        
        [Required]
        public string EmerContact { get; set; }

        public virtual IdentityRole Roles { get; set; }

        [NotMapped]
        public string SelectedRolesID { get; set; }

    }
}
