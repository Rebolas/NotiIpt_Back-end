using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotiIpt.Data;
using NotiIpt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotiIpt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Utilizadores1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Utilizadores1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Utilizadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilizadores>>> GetUtilizadores()
        {
            return await _context.Utilizadores.ToListAsync();
        }

        // GET: api/Utilizadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizadores>> GetUtilizadores(string id)
        {
            var utilizador = await _context.Utilizadores.FindAsync(id);

            if (utilizador == null)
            {
                return NotFound();
            }

            return utilizador;
        }

        // PUT: api/Utilizadores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizadores(string id, Utilizadores utilizador)
        {
            if (id != utilizador.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizadoresExists(id))
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

        // POST: api/Utilizadores
        [HttpPost]
        public async Task<ActionResult<Utilizadores>> PostUtilizadores(Utilizadores utilizador)
        {
            _context.Utilizadores.Add(utilizador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizadores", new { id = utilizador.Id }, utilizador);
        }

        // DELETE: api/Utilizadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilizadores(string id)
        {
            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            _context.Utilizadores.Remove(utilizador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilizadoresExists(string id)
        {
            return _context.Utilizadores.Any(e => e.Id == id);
        }
    }
}
