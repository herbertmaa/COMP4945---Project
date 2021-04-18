using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class EmployeeDescriptions
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int EmployeeDescriptionId { get; set; }
        public EmployeeDescription EmployeeDescription { get; set; }


    }
}
