using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class EmployeeHobby
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }
    }
}
