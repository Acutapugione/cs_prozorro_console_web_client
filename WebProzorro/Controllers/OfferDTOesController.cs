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
    public class OfferDTOesController : Controller
    {
        private readonly WebProzorroContext _context;

        public OfferDTOesController(WebProzorroContext context)
        {
            _context = context;
        }

        // GET: OfferDTOes
        public async Task<IActionResult> Index()
        {
              return _context.OfferDTOs != null ? 
                          View(await _context.OfferDTOs.ToListAsync()) :
                          Problem("Entity set 'WebProzorroContext.OfferDTO'  is null.");
        }

        // GET: OfferDTOes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.OfferDTOs == null)
            {
                return NotFound();
            }

            var offerDTO = await _context.OfferDTOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerDTO == null)
            {
                return NotFound();
            }

            return View(offerDTO);
        }

        // GET: OfferDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfferDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelatedProduct,Status,Comment,Owner,Id,DateModified")] OfferDTO offerDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offerDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offerDTO);
        }

        // GET: OfferDTOes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.OfferDTOs == null)
            {
                return NotFound();
            }

            var offerDTO = await _context.OfferDTOs.FindAsync(id);
            if (offerDTO == null)
            {
                return NotFound();
            }
            return View(offerDTO);
        }

        // POST: OfferDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RelatedProduct,Status,Comment,Owner,Id,DateModified")] OfferDTO offerDTO)
        {
            if (id != offerDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offerDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferDTOExists(offerDTO.Id))
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
            return View(offerDTO);
        }

        // GET: OfferDTOes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.OfferDTOs == null)
            {
                return NotFound();
            }

            var offerDTO = await _context.OfferDTOs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerDTO == null)
            {
                return NotFound();
            }

            return View(offerDTO);
        }

        // POST: OfferDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.OfferDTOs == null)
            {
                return Problem("Entity set 'WebProzorroContext.OfferDTO'  is null.");
            }
            var offerDTO = await _context.OfferDTOs.FindAsync(id);
            if (offerDTO != null)
            {
                _context.OfferDTOs.Remove(offerDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferDTOExists(string id)
        {
          return (_context.OfferDTOs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
