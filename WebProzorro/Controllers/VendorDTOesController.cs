using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prozorro.Models;
using WebProzorro.Data;

namespace WebProzorro.Controllers
{
    public class VendorDTOesController : Controller
    {
        private readonly WebProzorroContext _context;

        public VendorDTOesController(WebProzorroContext context)
        {
            _context = context;
        }

        // GET: VendorDTOes
        public async Task<IActionResult> Index()
        {
              return _context.VendorDTOs != null ? 
                          View(await _context.VendorDTOs.ToListAsync()) :
                          Problem("Entity set 'WebProzorroContext.VendorDTO'  is null.");
        }

        // GET: VendorDTOes/Details/5
        public async Task<IActionResult> Details(string id)
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

        // GET: VendorDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VendorDTOes/Create
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

        // GET: VendorDTOes/Edit/5
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

        // POST: VendorDTOes/Edit/5
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

        // GET: VendorDTOes/Delete/5
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

        // POST: VendorDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VendorDTOs == null)
            {
                return Problem("Entity set 'WebProzorroContext.VendorDTO'  is null.");
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
