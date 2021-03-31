using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAAS_Deployment.Models
{
    public class FullAddress
    {
        [Key]
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

    }
}
