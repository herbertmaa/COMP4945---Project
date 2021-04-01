using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Tenants
{
    public class Tenant
    {
        public int Id { get; set; }
        public string ConnectionString { get; set; }
        public string OrganizationName { get; set; }
        public string BranchName { get; set; }
    }
}
