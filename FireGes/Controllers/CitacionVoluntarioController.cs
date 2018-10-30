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
    public class CitacionVoluntarioController : Controller
    {
        private readonly FireGesContext _context;

        public CitacionVoluntarioController(FireGesContext context)
        {
            _context = context;
        }

        // GET: CitacionVoluntario
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.CitacionVoluntario.Include(c => c.IdCitacionNavigation).Include(c => c.IdVoluntarioNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: CitacionVoluntario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citacionVoluntario = await _context.CitacionVoluntario
                .Include(c => c.IdCitacionNavigation)
                .Include(c => c.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdCitacionVoluntario == id);
            if (citacionVoluntario == null)
            {
                return NotFound();
            }

            return View(citacionVoluntario);
        }

        // GET: CitacionVoluntario/Create
        public IActionResult Create()
        {
            ViewData["IdCitacion"] = new SelectList(_context.Citacion, "IdCitacion", "IdCitacion");
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario");
            return View();
        }

        // POST: CitacionVoluntario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCitacionVoluntario,IdVoluntario,IdCitacion")] CitacionVoluntario citacionVoluntario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citacionVoluntario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCitacion"] = new SelectList(_context.Citacion, "IdCitacion", "IdCitacion", citacionVoluntario.IdCitacion);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", citacionVoluntario.IdVoluntario);
            return View(citacionVoluntario);
        }

        // GET: CitacionVoluntario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citacionVoluntario = await _context.CitacionVoluntario.FindAsync(id);
            if (citacionVoluntario == null)
            {
                return NotFound();
            }
            ViewData["IdCitacion"] = new SelectList(_context.Citacion, "IdCitacion", "IdCitacion", citacionVoluntario.IdCitacion);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", citacionVoluntario.IdVoluntario);
            return View(citacionVoluntario);
        }

        // POST: CitacionVoluntario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCitacionVoluntario,IdVoluntario,IdCitacion")] CitacionVoluntario citacionVoluntario)
        {
            if (id != citacionVoluntario.IdCitacionVoluntario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citacionVoluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitacionVoluntarioExists(citacionVoluntario.IdCitacionVoluntario))
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
            ViewData["IdCitacion"] = new SelectList(_context.Citacion, "IdCitacion", "IdCitacion", citacionVoluntario.IdCitacion);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", citacionVoluntario.IdVoluntario);
            return View(citacionVoluntario);
        }

        // GET: CitacionVoluntario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citacionVoluntario = await _context.CitacionVoluntario
                .Include(c => c.IdCitacionNavigation)
                .Include(c => c.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdCitacionVoluntario == id);
            if (citacionVoluntario == null)
            {
                return NotFound();
            }

            return View(citacionVoluntario);
        }

        // POST: CitacionVoluntario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citacionVoluntario = await _context.CitacionVoluntario.FindAsync(id);
            _context.CitacionVoluntario.Remove(citacionVoluntario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitacionVoluntarioExists(int id)
        {
            return _context.CitacionVoluntario.Any(e => e.IdCitacionVoluntario == id);
        }
    }
}
