using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAAS_Deployment.Data;
using SAAS_Deployment.Models;

namespace SAAS_Deployment.Controllers
{
    public class EmployeeDescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeDescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeDescriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeDescriptions.Include(e => e.Employee).Include(e => e.EmployeeDescription);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDescriptions = await _context.EmployeeDescriptions
                .Include(e => e.Employee)
                .Include(e => e.EmployeeDescription)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeDescriptions == null)
            {
                return NotFound();
            }

            return View(employeeDescriptions);
        }

        // GET: EmployeeDescriptions/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Email");
            ViewData["EmployeeDescriptionId"] = new SelectList(_context.EmployeeDescription, "EmployeeDescriptionId", "EmployeeDescriptionId");
            return View();
        }

        // POST: EmployeeDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeDescriptionId")] EmployeeDescriptions employeeDescriptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDescriptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Email", employeeDescriptions.EmployeeId);
            ViewData["EmployeeDescriptionId"] = new SelectList(_context.EmployeeDescription, "EmployeeDescriptionId", "EmployeeDescriptionId", employeeDescriptions.EmployeeDescriptionId);
            return View(employeeDescriptions);
        }

        // GET: EmployeeDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDescriptions = await _context.EmployeeDescriptions.FindAsync(id);
            if (employeeDescriptions == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Email", employeeDescriptions.EmployeeId);
            ViewData["EmployeeDescriptionId"] = new SelectList(_context.EmployeeDescription, "EmployeeDescriptionId", "EmployeeDescriptionId", employeeDescriptions.EmployeeDescriptionId);
            return View(employeeDescriptions);
        }

        // POST: EmployeeDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmployeeDescriptionId")] EmployeeDescriptions employeeDescriptions)
        {
            if (id != employeeDescriptions.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDescriptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDescriptionsExists(employeeDescriptions.EmployeeId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Email", employeeDescriptions.EmployeeId);
            ViewData["EmployeeDescriptionId"] = new SelectList(_context.EmployeeDescription, "EmployeeDescriptionId", "EmployeeDescriptionId", employeeDescriptions.EmployeeDescriptionId);
            return View(employeeDescriptions);
        }

        // GET: EmployeeDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDescriptions = await _context.EmployeeDescriptions
                .Include(e => e.Employee)
                .Include(e => e.EmployeeDescription)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeDescriptions == null)
            {
                return NotFound();
            }

            return View(employeeDescriptions);
        }

        // POST: EmployeeDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDescriptions = await _context.EmployeeDescriptions.FindAsync(id);
            _context.EmployeeDescriptions.Remove(employeeDescriptions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDescriptionsExists(int id)
        {
            return _context.EmployeeDescriptions.Any(e => e.EmployeeId == id);
        }
    }
}
