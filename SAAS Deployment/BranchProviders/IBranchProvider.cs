using SAAS_Deployment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.BranchProviders
{
    public interface IBranchProvider
    {
        Branch GetBranch();
    }
}
