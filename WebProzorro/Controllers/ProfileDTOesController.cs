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
    public class ProfileDTOesController : Controller
    {
        private readonly WebProzorroContext _context;

        public ProfileDTOesController(WebProzorroContext context)
        {
            _context = context;
        }

        // GET: ProfileDTOes
        public async Task<IActionResult> Index()
        {
              return _context.ProfileDTOs != null ? 
                          View(await _context.ProfileDTOs.ToListAsync()) :
                          Problem("Entity set 'WebProzorroContext.ProfileDTO'  is null.");
        }

        // GET: ProfileDTOes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ProfileDTOs == null)
            {
                return NotFound();
            }

            var profileDTO = await _context.ProfileDTOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileDTO == null)
            {
                return NotFound();
            }

            return View(profileDTO);
        }

        // GET: ProfileDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfileDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Owner,RelatedCategory,Status,Title,Id,DateModified")] ProfileDTO profileDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileDTO);
        }

        // GET: ProfileDTOes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ProfileDTOs == null)
            {
                return NotFound();
            }

            var profileDTO = await _context.ProfileDTOs.FindAsync(id);
            if (profileDTO == null)
            {
                return NotFound();
            }
            return View(profileDTO);
        }

        // POST: ProfileDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Description,Owner,RelatedCategory,Status,Title,Id,DateModified")] ProfileDTO profileDTO)
        {
            if (id != profileDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileDTOExists(profileDTO.Id))
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
            return View(profileDTO);
        }

        // GET: ProfileDTOes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ProfileDTOs == null)
            {
                return NotFound();
            }

            var profileDTO = await _context.ProfileDTOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileDTO == null)
            {
                return NotFound();
            }

            return View(profileDTO);
        }

        // POST: ProfileDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ProfileDTOs == null)
            {
                return Problem("Entity set 'WebProzorroContext.ProfileDTO'  is null.");
            }
            var profileDTO = await _context.ProfileDTOs.FindAsync(id);
            if (profileDTO != null)
            {
                _context.ProfileDTOs.Remove(profileDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileDTOExists(string id)
        {
          return (_context.ProfileDTOs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
