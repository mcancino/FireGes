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
    public class DireccionVoluntarioController : Controller
    {
        private readonly FireGesContext _context;

        public DireccionVoluntarioController(FireGesContext context)
        {
            _context = context;
        }

        // GET: DireccionVoluntario
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.DireccionVoluntario.Include(d => d.IdComunaNavigation).Include(d => d.IdVoluntarioNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: DireccionVoluntario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionVoluntario = await _context.DireccionVoluntario
                .Include(d => d.IdComunaNavigation)
                .Include(d => d.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccionVoluntario == id);
            if (direccionVoluntario == null)
            {
                return NotFound();
            }

            return View(direccionVoluntario);
        }

        // GET: DireccionVoluntario/Create
        public IActionResult Create()
        {
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna");
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario");
            return View();
        }

        // POST: DireccionVoluntario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDireccionVoluntario,IdVoluntario,IdComuna,Calle,Numero,Departamento")] DireccionVoluntario direccionVoluntario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccionVoluntario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna", direccionVoluntario.IdComuna);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", direccionVoluntario.IdVoluntario);
            return View(direccionVoluntario);
        }

        // GET: DireccionVoluntario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionVoluntario = await _context.DireccionVoluntario.FindAsync(id);
            if (direccionVoluntario == null)
            {
                return NotFound();
            }
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna", direccionVoluntario.IdComuna);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", direccionVoluntario.IdVoluntario);
            return View(direccionVoluntario);
        }

        // POST: DireccionVoluntario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDireccionVoluntario,IdVoluntario,IdComuna,Calle,Numero,Departamento")] DireccionVoluntario direccionVoluntario)
        {
            if (id != direccionVoluntario.IdDireccionVoluntario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccionVoluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionVoluntarioExists(direccionVoluntario.IdDireccionVoluntario))
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
            ViewData["IdComuna"] = new SelectList(_context.Comuna, "IdComuna", "NombreComuna", direccionVoluntario.IdComuna);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", direccionVoluntario.IdVoluntario);
            return View(direccionVoluntario);
        }

        // GET: DireccionVoluntario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionVoluntario = await _context.DireccionVoluntario
                .Include(d => d.IdComunaNavigation)
                .Include(d => d.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccionVoluntario == id);
            if (direccionVoluntario == null)
            {
                return NotFound();
            }

            return View(direccionVoluntario);
        }

        // POST: DireccionVoluntario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccionVoluntario = await _context.DireccionVoluntario.FindAsync(id);
            _context.DireccionVoluntario.Remove(direccionVoluntario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionVoluntarioExists(int id)
        {
            return _context.DireccionVoluntario.Any(e => e.IdDireccionVoluntario == id);
        }
    }
}
