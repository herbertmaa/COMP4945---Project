using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace SAAS_Deployment.Tenants
{
    public class WebTenantProvider : ITenantProvider
    {
        private readonly ITenantSource _tenantSource;
        private readonly string _organization;
        private readonly string _branch;
        public WebTenantProvider(ITenantSource tenantSource, IHttpContextAccessor accessor)
        {
            _tenantSource = tenantSource;

            string path = accessor.HttpContext.Request.Path;

            string[] splitedPath = path.Split("/");
            if (splitedPath.Length > 2)
            {
                _organization = splitedPath[1];
                _branch = splitedPath[2];
            }
            /*            var routeData = accessor.HttpContext.Request.RouteValues;
                        _organization = routeData.GetValueOrDefault("organization")?.ToString();
                        _branch = routeData.GetValueOrDefault("branch")?.ToString();*/
        }

        public Tenant GetTenant()
        {
            var tenants = _tenantSource.ListTenants();

            return (_organization == null || _branch == null) ? null : tenants
                    .Where(t => t.OrganizationName.ToLower() == _organization.ToLower()
                    && t.BranchName.ToLower() == _branch.ToLower())
                    .FirstOrDefault();
        }
    }
}
