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
    public class DireccionCompaniaController : Controller
    {
        private readonly FireGesContext _context;

        public DireccionCompaniaController(FireGesContext context)
        {
            _context = context;
        }

        // GET: DireccionCompania
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.DireccionCompania.Include(d => d.IdCompaniaNavigation).Include(d => d.IdComunaNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: DireccionCompania/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCompania = await _context.DireccionCompania
                .Include(d => d.IdCompaniaNavigation)
                .Include(d => d.IdComunaNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccionCompania == id);
            if (direccionCompania == null)
            {
                return NotFound();
            }

            return View(direccionCompania);
        }

        // GET: DireccionCompania/Create
        public IActionResult Create()
        {
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania");
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna");
            return View();
        }

        // POST: DireccionCompania/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDireccionCompania,IdCompania,IdComuna,Calle,Numero,Departamento")] DireccionCompania direccionCompania)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccionCompania);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania", direccionCompania.IdCompania);
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna", direccionCompania.IdComuna);
            return View(direccionCompania);
        }

        // GET: DireccionCompania/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCompania = await _context.DireccionCompania.FindAsync(id);
            if (direccionCompania == null)
            {
                return NotFound();
            }
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania", direccionCompania.IdCompania);
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna", direccionCompania.IdComuna);
            return View(direccionCompania);
        }

        // POST: DireccionCompania/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDireccionCompania,IdCompania,IdComuna,Calle,Numero,Departamento")] DireccionCompania direccionCompania)
        {
            if (id != direccionCompania.IdDireccionCompania)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccionCompania);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionCompaniaExists(direccionCompania.IdDireccionCompania))
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
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania", direccionCompania.IdCompania);
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna", direccionCompania.IdComuna);
            return View(direccionCompania);
        }

        // GET: DireccionCompania/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCompania = await _context.DireccionCompania
                .Include(d => d.IdCompaniaNavigation)
                .Include(d => d.IdComunaNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccionCompania == id);
            if (direccionCompania == null)
            {
                return NotFound();
            }

            return View(direccionCompania);
        }

        // POST: DireccionCompania/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccionCompania = await _context.DireccionCompania.FindAsync(id);
            _context.DireccionCompania.Remove(direccionCompania);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionCompaniaExists(int id)
        {
            return _context.DireccionCompania.Any(e => e.IdDireccionCompania == id);
        }
    }
}
