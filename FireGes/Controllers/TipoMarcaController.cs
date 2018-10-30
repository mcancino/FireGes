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
    public class TipoMarcaController : Controller
    {
        private readonly FireGesContext _context;

        public TipoMarcaController(FireGesContext context)
        {
            _context = context;
        }

        // GET: TipoMarca
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMarca.ToListAsync());
        }

        // GET: TipoMarca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMarca = await _context.TipoMarca
                .FirstOrDefaultAsync(m => m.IdTipoMarca == id);
            if (tipoMarca == null)
            {
                return NotFound();
            }

            return View(tipoMarca);
        }

        // GET: TipoMarca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMarca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoMarca,DescripcionTipoMarca")] TipoMarca tipoMarca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMarca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMarca);
        }

        // GET: TipoMarca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMarca = await _context.TipoMarca.FindAsync(id);
            if (tipoMarca == null)
            {
                return NotFound();
            }
            return View(tipoMarca);
        }

        // POST: TipoMarca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoMarca,DescripcionTipoMarca")] TipoMarca tipoMarca)
        {
            if (id != tipoMarca.IdTipoMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMarca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMarcaExists(tipoMarca.IdTipoMarca))
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
            return View(tipoMarca);
        }

        // GET: TipoMarca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMarca = await _context.TipoMarca
                .FirstOrDefaultAsync(m => m.IdTipoMarca == id);
            if (tipoMarca == null)
            {
                return NotFound();
            }

            return View(tipoMarca);
        }

        // POST: TipoMarca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMarca = await _context.TipoMarca.FindAsync(id);
            _context.TipoMarca.Remove(tipoMarca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMarcaExists(int id)
        {
            return _context.TipoMarca.Any(e => e.IdTipoMarca == id);
        }
    }
}
