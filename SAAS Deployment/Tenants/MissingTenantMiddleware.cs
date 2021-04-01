using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SAAS_Deployment.Tenants
{
    public class MissingTenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _missingTenantUrl;

        public MissingTenantMiddleware(RequestDelegate next)
        {
            _next = next;
            _missingTenantUrl = "/facebook/burnaby";
        }

        public async Task Invoke(HttpContext context, ITenantProvider provider)
        {
            if (provider.GetTenant() == null)
            {
                context.Response.Redirect(_missingTenantUrl, permanent: false);
                return;
            }

            await _next.Invoke(context);
        }
    }
}
