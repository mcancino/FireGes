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
    public class MarcaVoluntarioController : Controller
    {
        private readonly FireGesContext _context;

        public MarcaVoluntarioController(FireGesContext context)
        {
            _context = context;
        }

        // GET: MarcaVoluntario
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.MarcaVoluntario.Include(m => m.IdTipoMarcaNavigation).Include(m => m.IdVoluntarioNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: MarcaVoluntario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaVoluntario = await _context.MarcaVoluntario
                .Include(m => m.IdTipoMarcaNavigation)
                .Include(m => m.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdMarcaVoluntario == id);
            if (marcaVoluntario == null)
            {
                return NotFound();
            }

            return View(marcaVoluntario);
        }

        // GET: MarcaVoluntario/Create
        public IActionResult Create()
        {
            ViewData["IdTipoMarca"] = new SelectList(_context.TipoMarca, "IdTipoMarca", "DescripcionTipoMarca");
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario");
            return View();
        }

        // POST: MarcaVoluntario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarcaVoluntario,IdVoluntario,IdTipoMarca,Fecha")] MarcaVoluntario marcaVoluntario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaVoluntario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoMarca"] = new SelectList(_context.TipoMarca, "IdTipoMarca", "DescripcionTipoMarca", marcaVoluntario.IdTipoMarca);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", marcaVoluntario.IdVoluntario);
            return View(marcaVoluntario);
        }

        // GET: MarcaVoluntario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaVoluntario = await _context.MarcaVoluntario.FindAsync(id);
            if (marcaVoluntario == null)
            {
                return NotFound();
            }
            ViewData["IdTipoMarca"] = new SelectList(_context.TipoMarca, "IdTipoMarca", "DescripcionTipoMarca", marcaVoluntario.IdTipoMarca);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", marcaVoluntario.IdVoluntario);
            return View(marcaVoluntario);
        }

        // POST: MarcaVoluntario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarcaVoluntario,IdVoluntario,IdTipoMarca,Fecha")] MarcaVoluntario marcaVoluntario)
        {
            if (id != marcaVoluntario.IdMarcaVoluntario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaVoluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaVoluntarioExists(marcaVoluntario.IdMarcaVoluntario))
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
            ViewData["IdTipoMarca"] = new SelectList(_context.TipoMarca, "IdTipoMarca", "DescripcionTipoMarca", marcaVoluntario.IdTipoMarca);
            ViewData["IdVoluntario"] = new SelectList(_context.Voluntario, "IdVoluntario", "IdVoluntario", marcaVoluntario.IdVoluntario);
            return View(marcaVoluntario);
        }

        // GET: MarcaVoluntario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaVoluntario = await _context.MarcaVoluntario
                .Include(m => m.IdTipoMarcaNavigation)
                .Include(m => m.IdVoluntarioNavigation)
                .FirstOrDefaultAsync(m => m.IdMarcaVoluntario == id);
            if (marcaVoluntario == null)
            {
                return NotFound();
            }

            return View(marcaVoluntario);
        }

        // POST: MarcaVoluntario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marcaVoluntario = await _context.MarcaVoluntario.FindAsync(id);
            _context.MarcaVoluntario.Remove(marcaVoluntario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaVoluntarioExists(int id)
        {
            return _context.MarcaVoluntario.Any(e => e.IdMarcaVoluntario == id);
        }
    }
}
