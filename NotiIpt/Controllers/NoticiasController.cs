using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotiIpt.Data;
using NotiIpt.Models;

namespace NotiIpt.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoticiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Noticias.ToListAsync());
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticias = await _context.Noticias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticias == null)
            {
                return NotFound();
            }

            return View(noticias);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Texto,DataEscrita")] Noticias noticias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticias);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticias = await _context.Noticias.FindAsync(id);
            if (noticias == null)
            {
                return NotFound();
            }
            return View(noticias);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Texto,DataEscrita")] Noticias noticias)
        {
            if (id != noticias.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiasExists(noticias.Id))
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
            return View(noticias);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticias = await _context.Noticias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticias == null)
            {
                return NotFound();
            }

            return View(noticias);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticias = await _context.Noticias.FindAsync(id);
            if (noticias != null)
            {
                _context.Noticias.Remove(noticias);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiasExists(int id)
        {
            return _context.Noticias.Any(e => e.Id == id);
        }
    }
}
