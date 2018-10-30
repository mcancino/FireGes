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
    public class UsuarioController : Controller
    {
        private readonly FireGesContext _context;

        public UsuarioController(FireGesContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var fireGesContext = _context.Usuario.Include(u => u.IdEstadoUsuarioNavigation).Include(u => u.IdPerfilNavigation);
            return View(await fireGesContext.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.IdEstadoUsuarioNavigation)
                .Include(u => u.IdPerfilNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoUsuario"] = new SelectList(_context.EstadoUsuario, "IdEstadoUsuario", "DescripcionEstadoUsuario");
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "DescripcionPerfil");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdPerfil,IdEstadoUsuario,NombreUsuario,Nombres,ApellidoPaterno,ApellidoMaterno,CorreoElectronico,Password")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoUsuario"] = new SelectList(_context.EstadoUsuario, "IdEstadoUsuario", "DescripcionEstadoUsuario", usuario.IdEstadoUsuario);
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "DescripcionPerfil", usuario.IdPerfil);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoUsuario"] = new SelectList(_context.EstadoUsuario, "IdEstadoUsuario", "DescripcionEstadoUsuario", usuario.IdEstadoUsuario);
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "DescripcionPerfil", usuario.IdPerfil);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,IdPerfil,IdEstadoUsuario,NombreUsuario,Nombres,ApellidoPaterno,ApellidoMaterno,CorreoElectronico,Password")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["IdEstadoUsuario"] = new SelectList(_context.EstadoUsuario, "IdEstadoUsuario", "DescripcionEstadoUsuario", usuario.IdEstadoUsuario);
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdPerfil", "DescripcionPerfil", usuario.IdPerfil);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.IdEstadoUsuarioNavigation)
                .Include(u => u.IdPerfilNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
