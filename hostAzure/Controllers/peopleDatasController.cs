using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hostAzure.Data;
using hostAzure.Models;

namespace hostAzure.Controllers
{
    public class peopleDatasController : Controller
    {
        private readonly peopleDbContext _context;

        public peopleDatasController(peopleDbContext context)
        {
            _context = context;
        }

        // GET: peopleDatas
        public async Task<IActionResult> Index()
        {
              return _context.People != null ? 
                          View(await _context.People.ToListAsync()) :
                          Problem("Entity set 'peopleDbContext.People'  is null.");
        }

        // GET: peopleDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var peopleData = await _context.People
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleData == null)
            {
                return NotFound();
            }

            return View(peopleData);
        }

        // GET: peopleDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: peopleDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,PhoneNumber,Email")] peopleData peopleData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peopleData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peopleData);
        }

        // GET: peopleDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var peopleData = await _context.People.FindAsync(id);
            if (peopleData == null)
            {
                return NotFound();
            }
            return View(peopleData);
        }

        // POST: peopleDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,PhoneNumber,Email")] peopleData peopleData)
        {
            if (id != peopleData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peopleData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!peopleDataExists(peopleData.Id))
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
            return View(peopleData);
        }

        // GET: peopleDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var peopleData = await _context.People
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleData == null)
            {
                return NotFound();
            }

            return View(peopleData);
        }

        // POST: peopleDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.People == null)
            {
                return Problem("Entity set 'peopleDbContext.People'  is null.");
            }
            var peopleData = await _context.People.FindAsync(id);
            if (peopleData != null)
            {
                _context.People.Remove(peopleData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool peopleDataExists(int id)
        {
          return (_context.People?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
