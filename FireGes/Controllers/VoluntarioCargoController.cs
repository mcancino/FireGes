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
    public class VoluntarioCargoController : Controller
    {
        private readonly FireGesContext _context;

        public VoluntarioCargoController(FireGesContext context)
        {
            _context = context;
        }

        // GET: VoluntarioCargo
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.VoluntarioCargo.Include(v => v.IdCargoNavigation).Include(v => v.IdVoluntarioNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: VoluntarioCargo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarioCargo = await _context.VoluntarioCargo
                .Include(v => v.IdCargoNavigation)
                .Include(v => v.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdVoluntarioCargo == id);
            if (voluntarioCargo == null)
            {
                return NotFound();
            }

            return View(voluntarioCargo);
        }

        // GET: VoluntarioCargo/Create
        public IActionResult Create()
        {
            ViewData["IdCargo"] = new SelectList(_context.Cargo, "IdCargo", "DescripcionCargo");
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario");
            return View();
        }

        // POST: VoluntarioCargo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVoluntarioCargo,IdCargo,IdVoluntario,FechaInicio,FechaTermino")] VoluntarioCargo voluntarioCargo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voluntarioCargo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargo, "IdCargo", "DescripcionCargo", voluntarioCargo.IdCargo);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", voluntarioCargo.IdVoluntario);
            return View(voluntarioCargo);
        }

        // GET: VoluntarioCargo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarioCargo = await _context.VoluntarioCargo.FindAsync(id);
            if (voluntarioCargo == null)
            {
                return NotFound();
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargo, "IdCargo", "DescripcionCargo", voluntarioCargo.IdCargo);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", voluntarioCargo.IdVoluntario);
            return View(voluntarioCargo);
        }

        // POST: VoluntarioCargo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVoluntarioCargo,IdCargo,IdVoluntario,FechaInicio,FechaTermino")] VoluntarioCargo voluntarioCargo)
        {
            if (id != voluntarioCargo.IdVoluntarioCargo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voluntarioCargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoluntarioCargoExists(voluntarioCargo.IdVoluntarioCargo))
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
            ViewData["IdCargo"] = new SelectList(_context.Cargo, "IdCargo", "DescripcionCargo", voluntarioCargo.IdCargo);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", voluntarioCargo.IdVoluntario);
            return View(voluntarioCargo);
        }

        // GET: VoluntarioCargo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarioCargo = await _context.VoluntarioCargo
                .Include(v => v.IdCargoNavigation)
                .Include(v => v.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdVoluntarioCargo == id);
            if (voluntarioCargo == null)
            {
                return NotFound();
            }

            return View(voluntarioCargo);
        }

        // POST: VoluntarioCargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voluntarioCargo = await _context.VoluntarioCargo.FindAsync(id);
            _context.VoluntarioCargo.Remove(voluntarioCargo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoluntarioCargoExists(int id)
        {
            return _context.VoluntarioCargo.Any(e => e.IdVoluntarioCargo == id);
        }
    }
}
