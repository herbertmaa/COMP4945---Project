using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using SAAS_Deployment.Models;

namespace SAAS_Deployment.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public DbSet<SAAS_Deployment.Models.Employee> Employee { get; set; }
        public DbSet<SAAS_Deployment.Models.FullAddress> FullAddress { get; set; }
        public DbSet<SAAS_Deployment.Models.Client> Client { get; set; }

        //public DbSet<IdentityRole> Roles { get; set; }
    }
}
