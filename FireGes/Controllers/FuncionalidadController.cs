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
    public class FuncionalidadController : Controller
    {
        private readonly FireGesContext _context;

        public FuncionalidadController(FireGesContext context)
        {
            _context = context;
        }

        // GET: Funcionalidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionalidad.ToListAsync());
        }

        // GET: Funcionalidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionalidad = await _context.Funcionalidad
                .FirstOrDefaultAsync(m => m.IdFuncionalidad == id);
            if (funcionalidad == null)
            {
                return NotFound();
            }

            return View(funcionalidad);
        }

        // GET: Funcionalidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionalidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFuncionalidad,DescripcionFuncionalidad,Controller,Metodo")] Funcionalidad funcionalidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionalidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionalidad);
        }

        // GET: Funcionalidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionalidad = await _context.Funcionalidad.FindAsync(id);
            if (funcionalidad == null)
            {
                return NotFound();
            }
            return View(funcionalidad);
        }

        // POST: Funcionalidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFuncionalidad,DescripcionFuncionalidad,Controller,Metodo")] Funcionalidad funcionalidad)
        {
            if (id != funcionalidad.IdFuncionalidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionalidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionalidadExists(funcionalidad.IdFuncionalidad))
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
            return View(funcionalidad);
        }

        // GET: Funcionalidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionalidad = await _context.Funcionalidad
                .FirstOrDefaultAsync(m => m.IdFuncionalidad == id);
            if (funcionalidad == null)
            {
                return NotFound();
            }

            return View(funcionalidad);
        }

        // POST: Funcionalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionalidad = await _context.Funcionalidad.FindAsync(id);
            _context.Funcionalidad.Remove(funcionalidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionalidadExists(int id)
        {
            return _context.Funcionalidad.Any(e => e.IdFuncionalidad == id);
        }
    }
}
