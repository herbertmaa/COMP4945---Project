using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class EmployeeDescription

    {
        [Key]
        public int EmployeeDescriptionId { get; set; }
        public string Description { get; set; }

        public IList<EmployeeDescriptions> EmployeeDescriptions { get; set; }

    }
}
