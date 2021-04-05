using SAAS_Deployment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.BranchProviders
{
    public class BranchProvider : IBranchProvider
    {


        public Branch GetBranch()
        {
            return new Branch
            {
                ID = 1,
                Name = "Branch1",
                DbConnectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-SAAS_Deployment-Branch1;Trusted_Connection=True;MultipleActiveResultSets=true"
            };
        }
    }
}
