using Microsoft.EntityFrameworkCore;
using SAAS_Deployment.Models;
using SAAS_Deployment.BranchProviders;

namespace SAAS_Deployment.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly Branch _branch;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IBranchProvider branchProvider)
            : base(options)
        {
            _branch = branchProvider.GetBranch();
        }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<FullAddress> FullAddress { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_branch.DbConnectionString);
        }

    }
}
