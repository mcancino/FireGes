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
    public class DisponibilidadController : Controller
    {
        private readonly FireGesContext _context;

        public DisponibilidadController(FireGesContext context)
        {
            _context = context;
        }

        // GET: Disponibilidad
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.Disponibilidad.Include(d => d.IdCompaniaNavigation).Include(d => d.IdVoluntarioNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: Disponibilidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad = await _context.Disponibilidad
                .Include(d => d.IdCompaniaNavigation)
                .Include(d => d.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDisponibilidad == id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return View(disponibilidad);
        }

        // GET: Disponibilidad/Create
        public IActionResult Create()
        {
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania");
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario");
            return View();
        }

        // POST: Disponibilidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDisponibilidad,IdVoluntario,IdCompania")] Disponibilidad disponibilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disponibilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania", disponibilidad.IdCompania);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", disponibilidad.IdVoluntario);
            return View(disponibilidad);
        }

        // GET: Disponibilidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad = await _context.Disponibilidad.FindAsync(id);
            if (disponibilidad == null)
            {
                return NotFound();
            }
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania", disponibilidad.IdCompania);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", disponibilidad.IdVoluntario);
            return View(disponibilidad);
        }

        // POST: Disponibilidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDisponibilidad,IdVoluntario,IdCompania")] Disponibilidad disponibilidad)
        {
            if (id != disponibilidad.IdDisponibilidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disponibilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisponibilidadExists(disponibilidad.IdDisponibilidad))
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
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania", disponibilidad.IdCompania);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", disponibilidad.IdVoluntario);
            return View(disponibilidad);
        }

        // GET: Disponibilidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad = await _context.Disponibilidad
                .Include(d => d.IdCompaniaNavigation)
                .Include(d => d.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDisponibilidad == id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return View(disponibilidad);
        }

        // POST: Disponibilidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disponibilidad = await _context.Disponibilidad.FindAsync(id);
            _context.Disponibilidad.Remove(disponibilidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisponibilidadExists(int id)
        {
            return _context.Disponibilidad.Any(e => e.IdDisponibilidad == id);
        }
    }
}
