﻿using System;
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
    public class DadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dados.ToListAsync());
        }

        // GET: Dados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dados = await _context.Dados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        // GET: Dados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHora,Temperatura,Humidade,lumino,Luz")] Dados dados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dados);
        }

        // GET: Dados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dados = await _context.Dados.FindAsync(id);
            if (dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        // POST: Dados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataHora,Temperatura,Humidade,lumino,Luz")] Dados dados)
        {
            if (id != dados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosExists(dados.Id))
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
            return View(dados);
        }

        // GET: Dados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dados = await _context.Dados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        // POST: Dados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dados = await _context.Dados.FindAsync(id);
            if (dados != null)
            {
                _context.Dados.Remove(dados);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosExists(int id)
        {
            return _context.Dados.Any(e => e.Id == id);
        }
    }
}
