using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SAAS_Deployment.Models;
using Microsoft.AspNetCore.Identity;

namespace SAAS_Deployment.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public DbSet<SAAS_Deployment.Models.Employee> Employee { get; set; }
        public DbSet<SAAS_Deployment.Models.FullAddress> FullAddress { get; set; }
        public DbSet<SAAS_Deployment.Models.Client> Client { get; set; }

    }
}
