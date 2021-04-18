﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DbConnectionString { get; set; }

        public IList<ApplicationUser> Users { get; set; }
    }
}
