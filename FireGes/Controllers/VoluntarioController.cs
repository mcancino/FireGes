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
    public class VoluntarioController : Controller
    {
        private readonly FireGesContext _context;

        public VoluntarioController(FireGesContext context)
        {
            _context = context;
        }

        // GET: Voluntario
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.Voluntario.Include(v => v.IdCompaniaNavigation).Include(v => v.IdEstadoVoluntarioNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: Voluntario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntario
                .Include(v => v.IdCompaniaNavigation)
                .Include(v => v.IdEstadoVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdVoluntario == id);
            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        // GET: Voluntario/Create
        public IActionResult Create()
        {
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania");
            ViewData["IdEstadoVoluntario"] = new SelectList(_context.EstadoVoluntario, "IdEstadoVoluntario", "DescripcionEstadoVoluntario");
            return View();
        }

        // POST: Voluntario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVoluntario,IdCompania,IdEstadoVoluntario,Rut,DigitoVerificador,Nombres,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,FechaIncorporacion")] Voluntario voluntario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voluntario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania", voluntario.IdCompania);
            ViewData["IdEstadoVoluntario"] = new SelectList(_context.EstadoVoluntario, "IdEstadoVoluntario", "DescripcionEstadoVoluntario", voluntario.IdEstadoVoluntario);
            return View(voluntario);
        }

        // GET: Voluntario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntario.FindAsync(id);
            if (voluntario == null)
            {
                return NotFound();
            }
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania", voluntario.IdCompania);
            ViewData["IdEstadoVoluntario"] = new SelectList(_context.EstadoVoluntario, "IdEstadoVoluntario", "DescripcionEstadoVoluntario", voluntario.IdEstadoVoluntario);
            return View(voluntario);
        }

        // POST: Voluntario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVoluntario,IdCompania,IdEstadoVoluntario,Rut,DigitoVerificador,Nombres,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,FechaIncorporacion")] Voluntario voluntario)
        {
            if (id != voluntario.IdVoluntario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoluntarioExists(voluntario.IdVoluntario))
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
            ViewData["IdCompania"] = new SelectList(_context.Compania, "IdCompania", "DenominacionCompania", voluntario.IdCompania);
            ViewData["IdEstadoVoluntario"] = new SelectList(_context.EstadoVoluntario, "IdEstadoVoluntario", "DescripcionEstadoVoluntario", voluntario.IdEstadoVoluntario);
            return View(voluntario);
        }

        // GET: Voluntario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntario = await _context.Voluntario
                .Include(v => v.IdCompaniaNavigation)
                .Include(v => v.IdEstadoVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdVoluntario == id);
            if (voluntario == null)
            {
                return NotFound();
            }

            return View(voluntario);
        }

        // POST: Voluntario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voluntario = await _context.Voluntario.FindAsync(id);
            _context.Voluntario.Remove(voluntario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoluntarioExists(int id)
        {
            return _context.Voluntario.Any(e => e.IdVoluntario == id);
        }
    }
}
