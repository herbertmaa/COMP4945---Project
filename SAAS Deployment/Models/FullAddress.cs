using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class FullAddress
    {
        [Key]
        public int ID { get; set; }

        public string Street { get; set; }

        public string City { get; set; }


        public string PostalCode { get; set; }

        [MaxLength(2,ErrorMessage = "The field Province must be a string of maximum length of '2'")]

        public string Province { get; set; }

        [MinLength(3)]
        public string Country { get; set; }

    }
}
