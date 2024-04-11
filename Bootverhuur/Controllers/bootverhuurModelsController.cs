using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bootverhuur.Data;
using Bootverhuur.Models;

namespace Bootverhuur.Controllers
{
    public class bootverhuurModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public bootverhuurModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: bootverhuurModels
        public async Task<IActionResult> Index()
        {
              return _context.bootverhuurModel != null ? 
                          View(await _context.bootverhuurModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.bootverhuurModel'  is null.");
        }

        // GET: bootverhuurModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bootverhuurModel == null)
            {
                return NotFound();
            }

            var bootverhuurModel = await _context.bootverhuurModel
                .FirstOrDefaultAsync(m => m.boat_Id == id);
            if (bootverhuurModel == null)
            {
                return NotFound();
            }

            return View(bootverhuurModel);
        }

        // GET: bootverhuurModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: bootverhuurModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("boat_Id,Owner_Id,Name,Type,Description,price_per_day,Image_URL,Speed,beds,petrol_litre,Petrol_type")] bootverhuurModel bootverhuurModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bootverhuurModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bootverhuurModel);
        }

        // GET: bootverhuurModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bootverhuurModel == null)
            {
                return NotFound();
            }

            var bootverhuurModel = await _context.bootverhuurModel.FindAsync(id);
            if (bootverhuurModel == null)
            {
                return NotFound();
            }
            return View(bootverhuurModel);
        }

        // POST: bootverhuurModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("boat_Id,Owner_Id,Name,Type,Description,price_per_day,Image_URL,Speed,beds,petrol_litre,Petrol_type")] bootverhuurModel bootverhuurModel)
        {
            if (id != bootverhuurModel.boat_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bootverhuurModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bootverhuurModelExists(bootverhuurModel.boat_Id))
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
            return View(bootverhuurModel);
        }

        // GET: bootverhuurModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bootverhuurModel == null)
            {
                return NotFound();
            }

            var bootverhuurModel = await _context.bootverhuurModel
                .FirstOrDefaultAsync(m => m.boat_Id == id);
            if (bootverhuurModel == null)
            {
                return NotFound();
            }

            return View(bootverhuurModel);
        }

        // POST: bootverhuurModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bootverhuurModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.bootverhuurModel'  is null.");
            }
            var bootverhuurModel = await _context.bootverhuurModel.FindAsync(id);
            if (bootverhuurModel != null)
            {
                _context.bootverhuurModel.Remove(bootverhuurModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bootverhuurModelExists(int id)
        {
          return (_context.bootverhuurModel?.Any(e => e.boat_Id == id)).GetValueOrDefault();
        }
    }
}
