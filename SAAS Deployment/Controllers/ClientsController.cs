using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAAS_Deployment.BranchProviders;
using SAAS_Deployment.Data;
using SAAS_Deployment.Models;

namespace SAAS_Deployment.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthDbContext _authContext;

        public ClientsController(ApplicationDbContext context, AuthDbContext authContext)
        {
            _context = context;
            _authContext = authContext;
        }

        // GET: Clients
        [Authorize(Policy = "readpolicy")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Client.Include(c => c.FullAddress).ToListAsync());
        }

        // GET: Clients/Details/5
        [Authorize(Policy = "readpolicy")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.Include(c => c.FullAddress)
                .FirstOrDefaultAsync(m => m.Person_Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        [Authorize(Policy = "writepolicy")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email")] Client client,
            [Bind("Street,City,PostalCode,Province,Country")] FullAddress fullAddress, [FromForm] string[] ExtraValueName, [FromForm] string[] Value)
        {
            if (ModelState.IsValid)
            {
                string jsonString = "";

                for (int i = 0; i < ExtraValueName.Length; i++)
                {
                    jsonString += ExtraValueName[i] + ":" + Value[i] + ",";
                }

                client.AdditionalInformation = jsonString;
                client.FullAddress = fullAddress;
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.Include(c => c.FullAddress).FirstOrDefaultAsync(c => c.Person_Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email")] Client client,
            [Bind("ID,Street,City,PostalCode,Province,Country")] FullAddress fullAddress, [FromForm] string[] ExtraValueName, [FromForm] string[] Value)
        {
            if (id != client.Person_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                string jsonString = "";

                for (int i = 0; i < ExtraValueName.Length; i++)
                {
                    jsonString += ExtraValueName[i] + ":" + Value[i] + ",";
                }

                client.AdditionalInformation = jsonString;
                try
                {
                    _context.Update(fullAddress);
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Person_Id))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Person_Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.Include(c => c.FullAddress).FirstOrDefaultAsync(c => c.Person_Id == id);
            _context.FullAddress.Remove(client.FullAddress);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Client/Transfer/5
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Transfer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.Include(c => c.FullAddress).FirstOrDefaultAsync(c => c.Person_Id == id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["branches"] = _authContext.Branch.ToList();
            return View(client);
        }

        // POST: Client/Transfer/5
        [HttpPost, ActionName("Transfer")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> TransferConfirmed(int id, int transferBranchId)
        {
            var client = await _context.Client.Include(c => c.FullAddress).FirstOrDefaultAsync(c => c.Person_Id == id);
            var address = client.FullAddress;

            Branch Branch = await _authContext.Branch.FindAsync(transferBranchId);
            var options = new DbContextOptions<ApplicationDbContext>();
            var provider = new DummyBranchProvider() { Branch = Branch };
            using var targetDbContext = new ApplicationDbContext(options, provider);

            if (targetDbContext.Client.Any(c => c.Email == client.Email))
            {
                throw new Exception("Client with same email already exist in target branch");
            }

            _context.FullAddress.Remove(client.FullAddress);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            client.Person_Id = 0;
            address.FullAddress_Id = 0;

            client.FullAddress = address;
            var addedEmployee = await targetDbContext.Client.AddAsync(client);
            await targetDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Person_Id == id);
        }
    }
}
