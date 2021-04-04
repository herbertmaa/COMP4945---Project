using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SAAS_Deployment.Data;
using SAAS_Deployment.Models;
using SAAS_Deployment.ViewModel;
using System.Collections.Generic;
using System.Linq;


namespace SAAS_Deployment.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<ApplicationUser> _userManager, ApplicationDbContext _dbContext, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            db = _dbContext;
            roleManager = _roleManager;
        }

        public IActionResult Index()
        {
            List<ApplicationUserRole> usersAndRoles = new List<ApplicationUserRole>();

            userManager.Users.ToList().ForEach(async user =>
            {
                IEnumerable<string> roles = await userManager.GetRolesAsync(user);
                usersAndRoles.Add(new ApplicationUserRole(user, roles));

            });

            return View(usersAndRoles);
        }


    }
}
