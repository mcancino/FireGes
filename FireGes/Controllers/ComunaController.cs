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
    public class ComunaController : Controller
    {
        private readonly FireGesContext _context;

        public ComunaController(FireGesContext context)
        {
            _context = context;
        }

        // GET: Comuna
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comuna.ToListAsync());
        }

        // GET: Comuna/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comuna = await _context.Comuna
                .FirstOrDefaultAsync(m => m.IdComuna == id);
            if (comuna == null)
            {
                return NotFound();
            }

            return View(comuna);
        }

        // GET: Comuna/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comuna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComuna,NombreComuna")] Comuna comuna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comuna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comuna);
        }

        // GET: Comuna/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comuna = await _context.Comuna.FindAsync(id);
            if (comuna == null)
            {
                return NotFound();
            }
            return View(comuna);
        }

        // POST: Comuna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComuna,NombreComuna")] Comuna comuna)
        {
            if (id != comuna.IdComuna)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comuna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComunaExists(comuna.IdComuna))
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
            return View(comuna);
        }

        // GET: Comuna/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comuna = await _context.Comuna
                .FirstOrDefaultAsync(m => m.IdComuna == id);
            if (comuna == null)
            {
                return NotFound();
            }

            return View(comuna);
        }

        // POST: Comuna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comuna = await _context.Comuna.FindAsync(id);
            _context.Comuna.Remove(comuna);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComunaExists(int id)
        {
            return _context.Comuna.Any(e => e.IdComuna == id);
        }
    }
}
