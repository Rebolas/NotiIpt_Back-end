﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotiIpt.Data;
using NotiIpt.Models;

namespace NotiIpt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Noticias1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Noticias1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Noticias1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoticiaViewModel>>> GetNoticias()
        {
            var i = await _context.Noticias.Include(f => f.ListaFotos).ToListAsync();
            var n = new List<NoticiaViewModel>();
            foreach (var t in i)
            { 
                var k = new NoticiaViewModel(t);
                k.ListaFotos= t.ListaFotos.Select(y => y.Nome).ToHashSet();
                n.Add(k);
                
            }
            return (n);
        }

        // GET: api/Noticias1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Noticias>> GetNoticias(int id)
        {
            var noticias = await _context.Noticias.FindAsync(id);

            if (noticias == null)
            {
                return NotFound();
            }

            return noticias;
        }

        // PUT: api/Noticias1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoticias(int id, Noticias noticias)
        {
            if (id != noticias.Id)
            {
                return BadRequest();
            }

            _context.Entry(noticias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Noticias1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Noticias>> PostNoticias(Noticias noticias)
        {
            _context.Noticias.Add(noticias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoticias", new { id = noticias.Id }, noticias);
        }

        // DELETE: api/Noticias1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoticias(int id)
        {
            var noticias = await _context.Noticias.FindAsync(id);
            if (noticias == null)
            {
                return NotFound();
            }

            _context.Noticias.Remove(noticias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoticiasExists(int id)
        {
            return _context.Noticias.Any(e => e.Id == id);
        }
    }
}
