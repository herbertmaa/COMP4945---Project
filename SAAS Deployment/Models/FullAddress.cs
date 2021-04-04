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
        [ForeignKey("Person")]
        public int FullAddressId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public virtual Person Person { get; set; }
    }
}
