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
    public class FullAddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FullAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FullAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.FullAddress.ToListAsync());
        }

        // GET: FullAddresses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fullAddress = await _context.FullAddress
                .FirstOrDefaultAsync(m => m.Street == id);
            if (fullAddress == null)
            {
                return NotFound();
            }

            return View(fullAddress);
        }

        // GET: FullAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FullAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Street,City,Province")] FullAddress fullAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fullAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fullAddress);
        }

        // GET: FullAddresses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fullAddress = await _context.FullAddress.FindAsync(id);
            if (fullAddress == null)
            {
                return NotFound();
            }
            return View(fullAddress);
        }

        // POST: FullAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Street,City,Province")] FullAddress fullAddress)
        {
            if (id != fullAddress.Street)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fullAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FullAddressExists(fullAddress.Street))
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
            return View(fullAddress);
        }

        // GET: FullAddresses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fullAddress = await _context.FullAddress
                .FirstOrDefaultAsync(m => m.Street == id);
            if (fullAddress == null)
            {
                return NotFound();
            }

            return View(fullAddress);
        }

        // POST: FullAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fullAddress = await _context.FullAddress.FindAsync(id);
            _context.FullAddress.Remove(fullAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FullAddressExists(string id)
        {
            return _context.FullAddress.Any(e => e.Street == id);
        }
    }
}
