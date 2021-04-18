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
    public class DescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Descriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeDescription.ToListAsync());
        }

        // GET: Descriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDescription = await _context.EmployeeDescription
                .FirstOrDefaultAsync(m => m.EmployeeDescriptionId == id);
            if (employeeDescription == null)
            {
                return NotFound();
            }

            return View(employeeDescription);
        }

        // GET: Descriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Descriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeDescriptionId,Description")] EmployeeDescription employeeDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDescription);
        }

        // GET: Descriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDescription = await _context.EmployeeDescription.FindAsync(id);
            if (employeeDescription == null)
            {
                return NotFound();
            }
            return View(employeeDescription);
        }

        // POST: Descriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeDescriptionId,Description")] EmployeeDescription employeeDescription)
        {
            if (id != employeeDescription.EmployeeDescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDescriptionExists(employeeDescription.EmployeeDescriptionId))
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
            return View(employeeDescription);
        }

        // GET: Descriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDescription = await _context.EmployeeDescription
                .FirstOrDefaultAsync(m => m.EmployeeDescriptionId == id);
            if (employeeDescription == null)
            {
                return NotFound();
            }

            return View(employeeDescription);
        }

        // POST: Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDescription = await _context.EmployeeDescription.FindAsync(id);
            _context.EmployeeDescription.Remove(employeeDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDescriptionExists(int id)
        {
            return _context.EmployeeDescription.Any(e => e.EmployeeDescriptionId == id);
        }
    }
}
