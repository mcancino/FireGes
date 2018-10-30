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
    public class EstadoUsuarioController : Controller
    {
        private readonly FireGesContext _context;

        public EstadoUsuarioController(FireGesContext context)
        {
            _context = context;
        }

        // GET: EstadoUsuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoUsuario.ToListAsync());
        }

        // GET: EstadoUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoUsuario = await _context.EstadoUsuario
                .FirstOrDefaultAsync(m => m.IdEstadoUsuario == id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }

            return View(estadoUsuario);
        }

        // GET: EstadoUsuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoUsuario,DescripcionEstadoUsuario")] EstadoUsuario estadoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoUsuario);
        }

        // GET: EstadoUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoUsuario = await _context.EstadoUsuario.FindAsync(id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }
            return View(estadoUsuario);
        }

        // POST: EstadoUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoUsuario,DescripcionEstadoUsuario")] EstadoUsuario estadoUsuario)
        {
            if (id != estadoUsuario.IdEstadoUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoUsuarioExists(estadoUsuario.IdEstadoUsuario))
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
            return View(estadoUsuario);
        }

        // GET: EstadoUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoUsuario = await _context.EstadoUsuario
                .FirstOrDefaultAsync(m => m.IdEstadoUsuario == id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }

            return View(estadoUsuario);
        }

        // POST: EstadoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoUsuario = await _context.EstadoUsuario.FindAsync(id);
            _context.EstadoUsuario.Remove(estadoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoUsuarioExists(int id)
        {
            return _context.EstadoUsuario.Any(e => e.IdEstadoUsuario == id);
        }
    }
}
