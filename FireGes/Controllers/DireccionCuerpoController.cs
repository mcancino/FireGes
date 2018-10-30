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
    public class DireccionCuerpoController : Controller
    {
        private readonly FireGesContext _context;

        public DireccionCuerpoController(FireGesContext context)
        {
            _context = context;
        }

        // GET: DireccionCuerpo
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.DireccionCuerpo.Include(d => d.IdComunaNavigation).Include(d => d.IdCuerpoNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: DireccionCuerpo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCuerpo = await _context.DireccionCuerpo
                .Include(d => d.IdComunaNavigation)
                .Include(d => d.IdCuerpoNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccionCuerpo == id);
            if (direccionCuerpo == null)
            {
                return NotFound();
            }

            return View(direccionCuerpo);
        }

        // GET: DireccionCuerpo/Create
        public IActionResult Create()
        {
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna");
            ViewData["IdCuerpo"] = new SelectList(_context.Cuerpo, "IdCuerpo", "Denominacion");
            return View();
        }

        // POST: DireccionCuerpo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDireccionCuerpo,IdCuerpo,IdComuna,Calle,Numero,Departamento")] DireccionCuerpo direccionCuerpo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccionCuerpo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna", direccionCuerpo.IdComuna);
            ViewData["IdCuerpo"] = new SelectList(_context.Cuerpo, "IdCuerpo", "Denominacion", direccionCuerpo.IdCuerpo);
            return View(direccionCuerpo);
        }

        // GET: DireccionCuerpo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCuerpo = await _context.DireccionCuerpo.FindAsync(id);
            if (direccionCuerpo == null)
            {
                return NotFound();
            }
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna", direccionCuerpo.IdComuna);
            ViewData["IdCuerpo"] = new SelectList(_context.Cuerpo, "IdCuerpo", "Denominacion", direccionCuerpo.IdCuerpo);
            return View(direccionCuerpo);
        }

        // POST: DireccionCuerpo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDireccionCuerpo,IdCuerpo,IdComuna,Calle,Numero,Departamento")] DireccionCuerpo direccionCuerpo)
        {
            if (id != direccionCuerpo.IdDireccionCuerpo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccionCuerpo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionCuerpoExists(direccionCuerpo.IdDireccionCuerpo))
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
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna", direccionCuerpo.IdComuna);
            ViewData["IdCuerpo"] = new SelectList(_context.Cuerpo, "IdCuerpo", "Denominacion", direccionCuerpo.IdCuerpo);
            return View(direccionCuerpo);
        }

        // GET: DireccionCuerpo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionCuerpo = await _context.DireccionCuerpo
                .Include(d => d.IdComunaNavigation)
                .Include(d => d.IdCuerpoNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccionCuerpo == id);
            if (direccionCuerpo == null)
            {
                return NotFound();
            }

            return View(direccionCuerpo);
        }

        // POST: DireccionCuerpo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccionCuerpo = await _context.DireccionCuerpo.FindAsync(id);
            _context.DireccionCuerpo.Remove(direccionCuerpo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionCuerpoExists(int id)
        {
            return _context.DireccionCuerpo.Any(e => e.IdDireccionCuerpo == id);
        }
    }
}
