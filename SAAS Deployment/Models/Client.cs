using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Models
{
    public class Client : Person
    {
        // Need to add one column that contains a JSON string for additional client info
        // ex: "Allergies": "Nut"
    }
}
