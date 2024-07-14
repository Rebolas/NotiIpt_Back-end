using System;
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
    public class Fotos1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Fotos1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fotos1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fotos>>> GetFotos()
        {
            return await _context.Fotos.ToListAsync();
        }

        // GET: api/Fotos1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fotos>> GetFotos(int id)
        {
            var fotos = await _context.Fotos.FindAsync(id);

            if (fotos == null)
            {
                return NotFound();
            }

            return fotos;
        }

        // PUT: api/Fotos1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFotos(int id, Fotos fotos)
        {
            if (id != fotos.Id)
            {
                return BadRequest();
            }

            _context.Entry(fotos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotosExists(id))
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

        // POST: api/Fotos1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fotos>> PostFotos(Fotos fotos)
        {
            _context.Fotos.Add(fotos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFotos", new { id = fotos.Id }, fotos);
        }

        // DELETE: api/Fotos1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFotos(int id)
        {
            var fotos = await _context.Fotos.FindAsync(id);
            if (fotos == null)
            {
                return NotFound();
            }

            _context.Fotos.Remove(fotos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FotosExists(int id)
        {
            return _context.Fotos.Any(e => e.Id == id);
        }
    }
}
