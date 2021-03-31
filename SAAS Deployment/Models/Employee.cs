using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public FullAddress fullAddress { get; set; }

        [Required]
        public DateTime DateJoined { get; set; }
        
        [Required]
        public string EmerContact { get; set; }

    }
}
