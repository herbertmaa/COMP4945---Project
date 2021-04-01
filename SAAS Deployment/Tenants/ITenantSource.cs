namespace SAAS_Deployment.Tenants
{
    public interface ITenantSource
    {
        Tenant[] ListTenants();
    }
}
