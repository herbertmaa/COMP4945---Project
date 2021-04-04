using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SAAS_Deployment.Models;
using Microsoft.AspNetCore.Identity;

namespace SAAS_Deployment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<FullAddress> FullAddress { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
            };

            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "password");

            //seed user
            builder.Entity<ApplicationUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }

    }
}
