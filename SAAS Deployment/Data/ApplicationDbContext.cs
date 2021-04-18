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

        public DbSet<EmployeeDescription> EmployeeDescription { get; set; }

        public DbSet<EmployeeDescriptions> EmployeeDescriptions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_branch.DbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDescriptions>().HasKey(sc => new { sc.EmployeeId, sc.EmployeeDescriptionId });


            modelBuilder.Entity<EmployeeDescriptions>()
            .HasOne<Employee>(sc => sc.Employee)
            .WithMany(s => s.EmployeeDescriptions)
            .HasForeignKey(sc => sc.EmployeeId);


            modelBuilder.Entity<EmployeeDescriptions>()
            .HasOne<EmployeeDescription>(sc => sc.EmployeeDescription)
            .WithMany(s => s.EmployeeDescriptions)
            .HasForeignKey(sc => sc.EmployeeDescriptionId);
        }

   

    }
}
