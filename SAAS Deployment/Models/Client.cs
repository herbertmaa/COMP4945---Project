using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class Client : Person
    {
        [StringLength(50)]
        [DisplayName("Additional Information")]
        public string AdditionalInformation { get; set; }
    }
}
