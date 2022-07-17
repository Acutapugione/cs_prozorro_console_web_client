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
    public class ProductDTOesController : Controller
    {
        private readonly WebProzorroContext _context;

        public ProductDTOesController(WebProzorroContext context)
        {
            _context = context;
        }

        // GET: ProductDTOes
        public async Task<IActionResult> Index()
        {
              return _context.ProductDTOs != null ? 
                          View(await _context.ProductDTOs.ToListAsync()) :
                          Problem("Entity set 'WebProzorroContext.ProductDTO'  is null.");
        }

        // GET: ProductDTOes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ProductDTOs == null)
            {
                return NotFound();
            }

            var productDTO = await _context.ProductDTOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDTO == null)
            {
                return NotFound();
            }

            return View(productDTO);
        }

        // GET: ProductDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,RelatedProfile,Description,Status,Owner,Id,DateModified")] ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productDTO);
        }

        // GET: ProductDTOes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ProductDTOs == null)
            {
                return NotFound();
            }

            var productDTO = await _context.ProductDTOs.FindAsync(id);
            if (productDTO == null)
            {
                return NotFound();
            }
            return View(productDTO);
        }

        // POST: ProductDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Title,RelatedProfile,Description,Status,Owner,Id,DateModified")] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDTOExists(productDTO.Id))
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
            return View(productDTO);
        }

        // GET: ProductDTOes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ProductDTOs == null)
            {
                return NotFound();
            }

            var productDTO = await _context.ProductDTOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productDTO == null)
            {
                return NotFound();
            }

            return View(productDTO);
        }

        // POST: ProductDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ProductDTOs == null)
            {
                return Problem("Entity set 'WebProzorroContext.ProductDTO'  is null.");
            }
            var productDTO = await _context.ProductDTOs.FindAsync(id);
            if (productDTO != null)
            {
                _context.ProductDTOs.Remove(productDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDTOExists(string id)
        {
          return (_context.ProductDTOs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
