using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAAS_Deployment.BranchProviders;
using SAAS_Deployment.Data;
using SAAS_Deployment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAAS_Deployment.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthDbContext _authContext;

        public EmployeesController(ApplicationDbContext context, AuthDbContext authContext)
        {
            _context = context;
            _authContext = authContext;
        }

        // GET: Employees
        [Authorize(Policy = "readpolicy")]
        public async Task<IActionResult> Index()
        {

            //var employees = await _context.Employee.ToListAsync();
            //var employeeDescriptions = await _context.EmployeeDescriptions.ToListAsync();
            var descriptions = await _context.EmployeeDescription.ToListAsync();

            /*
             var innerGroupJoinQuery2 =
                from e in employees
                join eds in employeeDescriptions 
                on e.Id equals eds.EmployeeId into empGroup
                from emp in empGroup
                join d in descriptions
                on emp.EmployeeDescriptionId equals d.EmployeeDescriptionId
                where d.Description == "Cool"
                select emp;

            Console.WriteLine(innerGroupJoinQuery2);
            */

            var employeesNamedRahim = await _context.Employee.Include(e => e.FullAddress).Include(e => e.EmployeeDescriptions).Where(e => e.FirstName == "Rahim").ToListAsync();
            return View(employeesNamedRahim);
        }

        // GET: Employees/Details/5
        [Authorize(Policy = "readpolicy")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.Include(e => e.FullAddress)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Create()
        {
            var descriptionList = await _context.EmployeeDescription.ToListAsync();
            ViewBag.DescriptionOptions = descriptionList;
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Create([Bind("DateJoined,EmerContact,Id,FirstName,LastName,Email")] Employee employee,
            [Bind("Street,City,PostalCode,Province,Country")] FullAddress fullAddress, [FromForm] List<int> Description)
        {
            if (ModelState.IsValid)
            {

                foreach (int d in Description)
                {

                    EmployeeDescriptions eds = new EmployeeDescriptions
                    {

                        Employee = employee,
                        EmployeeDescriptionId = d
                    };
                    _context.Add(eds);

                }
                employee.FullAddress = fullAddress;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.Include(e => e.FullAddress).FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Edit(int id, [Bind("DateJoined,EmerContact,Id,FirstName,LastName,Email")] Employee employee,
            [Bind("ID,Street,City,PostalCode,Province,Country")] FullAddress fullAddress)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fullAddress);
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.Include(c => c.FullAddress).FirstOrDefaultAsync(c => c.Id == id);
            _context.FullAddress.Remove(employee.FullAddress);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Transfer/5
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Transfer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.Include(e => e.FullAddress).FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["branches"] = _authContext.Branch.ToList();
            return View(employee);
        }

        // POST: Employees/Transfer/5
        [HttpPost, ActionName("Transfer")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> TransferConfirmed(int id, int transferBranchId)
        {

            var employee = await _context.Employee.Include(c => c.FullAddress).FirstOrDefaultAsync(c => c.Id == id);
            var address = employee.FullAddress;

            Branch Branch = await _authContext.Branch.FindAsync(transferBranchId);
            var options = new DbContextOptions<ApplicationDbContext>();
            var provider = new DummyBranchProvider() { Branch = Branch };
            using var targetDbContext = new ApplicationDbContext(options, provider);

            if (targetDbContext.Employee.Any(e => e.Email == employee.Email))
            {
                throw new Exception("Employee with same email already exist in target branch");
            }

            _context.FullAddress.Remove(employee.FullAddress);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            employee.Id = 0;
            address.ID = 0;

            employee.FullAddress = address;
            var addedEmployee = await targetDbContext.Employee.AddAsync(employee);
            await targetDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }

    }
}
