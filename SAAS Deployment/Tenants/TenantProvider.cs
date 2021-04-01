using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Tenants
{
    public class TenantProvider : ITenantProvider
    {
        public Tenant Tenant { get; set; }

        public Tenant GetTenant()
        {
            return Tenant;
        }
    }
}
