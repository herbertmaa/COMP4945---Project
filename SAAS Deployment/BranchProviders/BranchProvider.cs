using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SAAS_Deployment.Data;
using SAAS_Deployment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.BranchProviders
{
    public class BranchProvider : IBranchProvider
    {
        private readonly string _username;
        private readonly AuthDbContext _context;
        public BranchProvider(IHttpContextAccessor accessor, AuthDbContext context)
        {
            _username = accessor.HttpContext.User.Identity.Name;
            _context = context;
        }

        public Branch GetBranch()
        {
            if (_username != null)
            {
                int branchId = _context.Users.FirstOrDefault(u => u.UserName == _username).BranchId;
                Branch Branch = _context.Branch.Find(branchId);

                var options = new DbContextOptions<ApplicationDbContext>();
                var provider = new DummyBranchProvider() { Branch = Branch };
                using var dbContext = new ApplicationDbContext(options, provider);
                dbContext.Database.Migrate();
                return Branch;
            }
            else
            {
                return new Branch
                {
                    ID = 0,
                    Name = "SAAS Deployment",
                    DbConnectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-SAAS_Deployment-Branch1;Trusted_Connection=True;MultipleActiveResultSets=true"
                };
            }

            //return new Branch { DbConnectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-SAAS_Deployment-Branch1;Trusted_Connection=True;MultipleActiveResultSets=true" };
        }
    }
}
