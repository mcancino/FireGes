using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FireGes.Models;

namespace FireGes.Controllers
{
    public class CompaniaController : Controller
    {
        private readonly FireGesContext _context;

        public CompaniaController(FireGesContext context)
        {
            _context = context;
        }

        // GET: Compania
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.Compania.Include(c => c.IdCuerpoNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: Compania/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compania = await _context.Compania
                .Include(c => c.IdCuerpoNavigation)
                .FirstOrDefaultAsync(m => m.IdCompania == id);
            if (compania == null)
            {
                return NotFound();
            }

            return View(compania);
        }

        // GET: Compania/Create
        public IActionResult Create()
        {
            ViewData["IdCuerpo"] = new SelectList(_context.Cuerpo, "IdCuerpo", "Denominacion");
            return View();
        }

        // POST: Compania/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompania,IdCuerpo,DenominacionCompania,NombreFantasia")] Compania compania)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compania);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCuerpo"] = new SelectList(_context.Cuerpo, "IdCuerpo", "Denominacion", compania.IdCuerpo);
            return View(compania);
        }

        // GET: Compania/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compania = await _context.Compania.FindAsync(id);
            if (compania == null)
            {
                return NotFound();
            }
            ViewData["IdCuerpo"] = new SelectList(_context.Cuerpo, "IdCuerpo", "Denominacion", compania.IdCuerpo);
            return View(compania);
        }

        // POST: Compania/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompania,IdCuerpo,DenominacionCompania,NombreFantasia")] Compania compania)
        {
            if (id != compania.IdCompania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compania);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompaniaExists(compania.IdCompania))
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
            ViewData["IdCuerpo"] = new SelectList(_context.Cuerpo, "IdCuerpo", "Denominacion", compania.IdCuerpo);
            return View(compania);
        }

        // GET: Compania/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compania = await _context.Compania
                .Include(c => c.IdCuerpoNavigation)
                .FirstOrDefaultAsync(m => m.IdCompania == id);
            if (compania == null)
            {
                return NotFound();
            }

            return View(compania);
        }

        // POST: Compania/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compania = await _context.Compania.FindAsync(id);
            _context.Compania.Remove(compania);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompaniaExists(int id)
        {
            return _context.Compania.Any(e => e.IdCompania == id);
        }
    }
}
