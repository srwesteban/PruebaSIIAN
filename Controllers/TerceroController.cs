using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tienda2.Models;

namespace Tienda2.Controllers
{
    public class TerceroController : Controller
    {
        private readonly TiendaContext _context;

        public TerceroController(TiendaContext context)
        {
            _context = context;
        }

        // GET: Tercero
        public async Task<IActionResult> Index()
        {
            return View(await _context.Terceros.ToListAsync());
        }

        // GET: Tercero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        // GET: Tercero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tercero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Identificacion,Apellido1,Apellido2,Nombre1,Nombre2,Edad")] Tercero tercero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tercero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tercero);
        }

        // GET: Tercero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros.FindAsync(id);
            if (tercero == null)
            {
                return NotFound();
            }
            return View(tercero);
        }

        // POST: Tercero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Identificacion,Apellido1,Apellido2,Nombre1,Nombre2,Edad")] Tercero tercero)
        {
            if (id != tercero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tercero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerceroExists(tercero.Id))
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
            return View(tercero);
        }

        // GET: Tercero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        // POST: Tercero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tercero = await _context.Terceros.FindAsync(id);
            if (tercero != null)
            {
                _context.Terceros.Remove(tercero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerceroExists(int id)
        {
            return _context.Terceros.Any(e => e.Id == id);
        }
    }
}
