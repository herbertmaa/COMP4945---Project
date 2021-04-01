using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAAS_Deployment.Tenants;
using System;
using System.Collections.Generic;
using System.Text;
using SAAS_Deployment.Models;


namespace SAAS_Deployment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        private readonly Tenant _tenant;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ITenantProvider tenantProvider)
            : base(options)
        {
            _tenant = tenantProvider.GetTenant();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_tenant.ConnectionString);
        }
        public string OrganizationName { get { return _tenant.OrganizationName; } }
        public string BranchName { get { return _tenant.BranchName; } }

        public DbSet<SAAS_Deployment.Models.Employee> Employee { get; set; }
        public DbSet<SAAS_Deployment.Models.FullAddress> FullAddress { get; set; }
        public DbSet<SAAS_Deployment.Models.Client> Client { get; set; }
    }
}
