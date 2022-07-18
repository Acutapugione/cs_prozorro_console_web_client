using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProzorro.Data;
using WebProzorro.Models;

namespace WebProzorro.Controllers
{
    public class DVendorsController : Controller
    {
        private readonly WebProzorroContext _context;

        public DVendorsController(WebProzorroContext context)
        {
            _context = context;
        }

        // GET: DVendors
        public async Task<IActionResult> Index()
        {
              return _context.VendorDTOs != null ? 
                          View(await _context.VendorDTOs.ToListAsync()) :
                          Problem("Entity set 'WebProzorroContext.VendorDTOs'  is null.");
        }

        // GET: DVendors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VendorDTOs == null)
            {
                return NotFound();
            }

            var vendorDTO = await _context.VendorDTOs
                .Include(x => x.Categories)
                .Include(x => x.Documents)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorDTO == null)
            {
                return NotFound();
            }

            return View(vendorDTO);
        }

        // GET: DVendors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DVendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IsActivated,DateCreated,Status,Owner,Id,DateModified")] VendorDTO vendorDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendorDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendorDTO);
        }

        // GET: DVendors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VendorDTOs == null)
            {
                return NotFound();
            }

            var vendorDTO = await _context.VendorDTOs.FindAsync(id);
            if (vendorDTO == null)
            {
                return NotFound();
            }
            return View(vendorDTO);
        }

        // POST: DVendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IsActivated,DateCreated,Status,Owner,Id,DateModified")] VendorDTO vendorDTO)
        {
            if (id != vendorDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendorDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorDTOExists(vendorDTO.Id))
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
            return View(vendorDTO);
        }

        // GET: DVendors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VendorDTOs == null)
            {
                return NotFound();
            }

            var vendorDTO = await _context.VendorDTOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorDTO == null)
            {
                return NotFound();
            }

            return View(vendorDTO);
        }

        // POST: DVendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VendorDTOs == null)
            {
                return Problem("Entity set 'WebProzorroContext.VendorDTOs'  is null.");
            }
            var vendorDTO = await _context.VendorDTOs.FindAsync(id);
            if (vendorDTO != null)
            {
                _context.VendorDTOs.Remove(vendorDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorDTOExists(string id)
        {
          return (_context.VendorDTOs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
