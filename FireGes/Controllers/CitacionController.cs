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
    public class CitacionController : Controller
    {
        private readonly FireGesContext _context;

        public CitacionController(FireGesContext context)
        {
            _context = context;
        }

        // GET: Citacion
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.Citacion.Include(c => c.IdTipoCitacionNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: Citacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citacion = await _context.Citacion
                .Include(c => c.IdTipoCitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdCitacion == id);
            if (citacion == null)
            {
                return NotFound();
            }

            return View(citacion);
        }

        // GET: Citacion/Create
        public IActionResult Create()
        {
            ViewData["IdTipoCitacion"] = new SelectList(_context.TipoCitacion, "IdTipoCitacion", "DescripcionTipoCitacion");
            return View();
        }

        // POST: Citacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCitacion,IdTipoCitacion,FechaCitacion")] Citacion citacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoCitacion"] = new SelectList(_context.TipoCitacion, "IdTipoCitacion", "DescripcionTipoCitacion", citacion.IdTipoCitacion);
            return View(citacion);
        }

        // GET: Citacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citacion = await _context.Citacion.FindAsync(id);
            if (citacion == null)
            {
                return NotFound();
            }
            ViewData["IdTipoCitacion"] = new SelectList(_context.TipoCitacion, "IdTipoCitacion", "DescripcionTipoCitacion", citacion.IdTipoCitacion);
            return View(citacion);
        }

        // POST: Citacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCitacion,IdTipoCitacion,FechaCitacion")] Citacion citacion)
        {
            if (id != citacion.IdCitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitacionExists(citacion.IdCitacion))
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
            ViewData["IdTipoCitacion"] = new SelectList(_context.TipoCitacion, "IdTipoCitacion", "DescripcionTipoCitacion", citacion.IdTipoCitacion);
            return View(citacion);
        }

        // GET: Citacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citacion = await _context.Citacion
                .Include(c => c.IdTipoCitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdCitacion == id);
            if (citacion == null)
            {
                return NotFound();
            }

            return View(citacion);
        }

        // POST: Citacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citacion = await _context.Citacion.FindAsync(id);
            _context.Citacion.Remove(citacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitacionExists(int id)
        {
            return _context.Citacion.Any(e => e.IdCitacion == id);
        }
    }
}
