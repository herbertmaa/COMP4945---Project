using Newtonsoft.Json;
using System.IO;

namespace SAAS_Deployment.Tenants
{
    public class TenantSource : ITenantSource
    {
        public Tenant[] ListTenants()
        {
            var tenants = File.ReadAllText("tenants.json");
            return JsonConvert.DeserializeObject<Tenant[]>(tenants);
        }
    }
}
