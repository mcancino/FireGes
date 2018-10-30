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
    public class EstadoVoluntarioController : Controller
    {
        private readonly FireGesContext _context;

        public EstadoVoluntarioController(FireGesContext context)
        {
            _context = context;
        }

        // GET: EstadoVoluntario
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoVoluntario.ToListAsync());
        }

        // GET: EstadoVoluntario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoVoluntario = await _context.EstadoVoluntario
                .FirstOrDefaultAsync(m => m.IdEstadoVoluntario == id);
            if (estadoVoluntario == null)
            {
                return NotFound();
            }

            return View(estadoVoluntario);
        }

        // GET: EstadoVoluntario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoVoluntario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoVoluntario,DescripcionEstadoVoluntario")] EstadoVoluntario estadoVoluntario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoVoluntario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoVoluntario);
        }

        // GET: EstadoVoluntario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoVoluntario = await _context.EstadoVoluntario.FindAsync(id);
            if (estadoVoluntario == null)
            {
                return NotFound();
            }
            return View(estadoVoluntario);
        }

        // POST: EstadoVoluntario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoVoluntario,DescripcionEstadoVoluntario")] EstadoVoluntario estadoVoluntario)
        {
            if (id != estadoVoluntario.IdEstadoVoluntario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoVoluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoVoluntarioExists(estadoVoluntario.IdEstadoVoluntario))
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
            return View(estadoVoluntario);
        }

        // GET: EstadoVoluntario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoVoluntario = await _context.EstadoVoluntario
                .FirstOrDefaultAsync(m => m.IdEstadoVoluntario == id);
            if (estadoVoluntario == null)
            {
                return NotFound();
            }

            return View(estadoVoluntario);
        }

        // POST: EstadoVoluntario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoVoluntario = await _context.EstadoVoluntario.FindAsync(id);
            _context.EstadoVoluntario.Remove(estadoVoluntario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoVoluntarioExists(int id)
        {
            return _context.EstadoVoluntario.Any(e => e.IdEstadoVoluntario == id);
        }
    }
}
