using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotiIpt.Data;
using NotiIpt.Models;

namespace NotiIpt
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dados1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dados>>> GetDados()
        {
            return await _context.Dados.ToListAsync();
        }

        // GET: api/Dados1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dados>> GetDados(int id)
        {
            var dados = await _context.Dados.FindAsync(id);

            if (dados == null)
            {
                return NotFound();
            }

            return dados;
        }

        // PUT: api/Dados1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDados(int id, Dados dados)
        {
            if (id != dados.Id)
            {
                return BadRequest();
            }

            _context.Entry(dados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DadosExists(id))
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

        // POST: api/Dados1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dados>> PostDados(Dados dados)
        {
            _context.Dados.Add(dados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDados", new { id = dados.Id }, dados);
        }

        // DELETE: api/Dados1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDados(int id)
        {
            var dados = await _context.Dados.FindAsync(id);
            if (dados == null)
            {
                return NotFound();
            }

            _context.Dados.Remove(dados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DadosExists(int id)
        {
            return _context.Dados.Any(e => e.Id == id);
        }
    }
}
