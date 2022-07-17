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
    public class CategoryDTOesController : Controller
    {
        private readonly WebProzorroContext _context;

        public CategoryDTOesController(WebProzorroContext context)
        {
            _context = context;
        }

        // GET: CategoryDTOes
        public async Task<IActionResult> Index()
        {
            return _context.CategoryDTOs != null ?
                        View(await _context.CategoryDTOs.ToListAsync()) :
                        Problem("Entity set 'WebProzorroContext.CategoryDTO'  is null.");
        }

        // GET: CategoryDTOes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CategoryDTOs == null)
            {
                return NotFound();
            }

            var categoryDTO = await _context.CategoryDTOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryDTO == null)
            {
                return NotFound();
            }

            return View(categoryDTO);
        }

        // GET: CategoryDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Status,Title,Id,DateModified")] CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        // GET: CategoryDTOes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CategoryDTOs == null)
            {
                return NotFound();
            }

            var categoryDTO = await _context.CategoryDTOs.FindAsync(id);
            if (categoryDTO == null)
            {
                return NotFound();
            }
            return View(categoryDTO);
        }

        // POST: CategoryDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Description,Status,Title,Id,DateModified")] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryDTOExists(categoryDTO.Id))
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
            return View(categoryDTO);
        }

        // GET: CategoryDTOes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CategoryDTOs == null)
            {
                return NotFound();
            }

            var categoryDTO = await _context.CategoryDTOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryDTO == null)
            {
                return NotFound();
            }

            return View(categoryDTO);
        }

        // POST: CategoryDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CategoryDTOs == null)
            {
                return Problem("Entity set 'WebProzorroContext.CategoryDTO'  is null.");
            }
            var categoryDTO = await _context.CategoryDTOs.FindAsync(id);
            if (categoryDTO != null)
            {
                _context.CategoryDTOs.Remove(categoryDTO);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryDTOExists(string id)
        {
            return (_context.CategoryDTOs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
