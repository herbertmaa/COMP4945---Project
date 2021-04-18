using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{   
    public class Person
    {
        [Key]
        public int Person_Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    
        public FullAddress FullAddress { get; set; }

        [NotMapped]
        public int TransferBranchId { get; set; }
    }
}
