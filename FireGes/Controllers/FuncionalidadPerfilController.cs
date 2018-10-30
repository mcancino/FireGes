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
    public class FuncionalidadPerfilController : Controller
    {
        private readonly FireGesContext _context;

        public FuncionalidadPerfilController(FireGesContext context)
        {
            _context = context;
        }

        // GET: FuncionalidadPerfil
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.FuncionalidadPerfil.Include(f => f.IdFuncionalidadNavigation).Include(f => f.IdPerfilNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: FuncionalidadPerfil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionalidadPerfil = await _context.FuncionalidadPerfil
                .Include(f => f.IdFuncionalidadNavigation)
                .Include(f => f.IdPerfilNavigation)
                .FirstOrDefaultAsync(m => m.IdFuncionalidadPerfil == id);
            if (funcionalidadPerfil == null)
            {
                return NotFound();
            }

            return View(funcionalidadPerfil);
        }

        // GET: FuncionalidadPerfil/Create
        public IActionResult Create()
        {
            ViewData["IdFuncionalidad"] = new SelectList(_context.Funcionalidad, "IdFuncionalidad", "Controller");
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "DescripcionPerfil");
            return View();
        }

        // POST: FuncionalidadPerfil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFuncionalidadPerfil,IdFuncionalidad,IdPerfil")] FuncionalidadPerfil funcionalidadPerfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionalidadPerfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFuncionalidad"] = new SelectList(_context.Funcionalidad, "IdFuncionalidad", "Controller", funcionalidadPerfil.IdFuncionalidad);
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "DescripcionPerfil", funcionalidadPerfil.IdPerfil);
            return View(funcionalidadPerfil);
        }

        // GET: FuncionalidadPerfil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionalidadPerfil = await _context.FuncionalidadPerfil.FindAsync(id);
            if (funcionalidadPerfil == null)
            {
                return NotFound();
            }
            ViewData["IdFuncionalidad"] = new SelectList(_context.Funcionalidad, "IdFuncionalidad", "Controller", funcionalidadPerfil.IdFuncionalidad);
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "DescripcionPerfil", funcionalidadPerfil.IdPerfil);
            return View(funcionalidadPerfil);
        }

        // POST: FuncionalidadPerfil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFuncionalidadPerfil,IdFuncionalidad,IdPerfil")] FuncionalidadPerfil funcionalidadPerfil)
        {
            if (id != funcionalidadPerfil.IdFuncionalidadPerfil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionalidadPerfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionalidadPerfilExists(funcionalidadPerfil.IdFuncionalidadPerfil))
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
            ViewData["IdFuncionalidad"] = new SelectList(_context.Funcionalidad, "IdFuncionalidad", "Controller", funcionalidadPerfil.IdFuncionalidad);
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "DescripcionPerfil", funcionalidadPerfil.IdPerfil);
            return View(funcionalidadPerfil);
        }

        // GET: FuncionalidadPerfil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionalidadPerfil = await _context.FuncionalidadPerfil
                .Include(f => f.IdFuncionalidadNavigation)
                .Include(f => f.IdPerfilNavigation)
                .FirstOrDefaultAsync(m => m.IdFuncionalidadPerfil == id);
            if (funcionalidadPerfil == null)
            {
                return NotFound();
            }

            return View(funcionalidadPerfil);
        }

        // POST: FuncionalidadPerfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionalidadPerfil = await _context.FuncionalidadPerfil.FindAsync(id);
            _context.FuncionalidadPerfil.Remove(funcionalidadPerfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionalidadPerfilExists(int id)
        {
            return _context.FuncionalidadPerfil.Any(e => e.IdFuncionalidadPerfil == id);
        }
    }
}
