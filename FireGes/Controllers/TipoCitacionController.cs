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
    public class TipoCitacionController : Controller
    {
        private readonly FireGesContext _context;

        public TipoCitacionController(FireGesContext context)
        {
            _context = context;
        }

        // GET: TipoCitacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoCitacion.ToListAsync());
        }

        // GET: TipoCitacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCitacion = await _context.TipoCitacion
                .FirstOrDefaultAsync(m => m.IdTipoCitacion == id);
            if (tipoCitacion == null)
            {
                return NotFound();
            }

            return View(tipoCitacion);
        }

        // GET: TipoCitacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCitacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCitacion,DescripcionTipoCitacion")] TipoCitacion tipoCitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCitacion);
        }

        // GET: TipoCitacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCitacion = await _context.TipoCitacion.FindAsync(id);
            if (tipoCitacion == null)
            {
                return NotFound();
            }
            return View(tipoCitacion);
        }

        // POST: TipoCitacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCitacion,DescripcionTipoCitacion")] TipoCitacion tipoCitacion)
        {
            if (id != tipoCitacion.IdTipoCitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCitacionExists(tipoCitacion.IdTipoCitacion))
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
            return View(tipoCitacion);
        }

        // GET: TipoCitacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCitacion = await _context.TipoCitacion
                .FirstOrDefaultAsync(m => m.IdTipoCitacion == id);
            if (tipoCitacion == null)
            {
                return NotFound();
            }

            return View(tipoCitacion);
        }

        // POST: TipoCitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoCitacion = await _context.TipoCitacion.FindAsync(id);
            _context.TipoCitacion.Remove(tipoCitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCitacionExists(int id)
        {
            return _context.TipoCitacion.Any(e => e.IdTipoCitacion == id);
        }
    }
}
