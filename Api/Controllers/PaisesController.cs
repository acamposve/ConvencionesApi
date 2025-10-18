using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/paises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
            return await _context.Paises.ToListAsync();
        }

        // GET: api/paises/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(Guid id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
                return NotFound();

            return pais;
        }

        // POST: api/paises
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            pais.Id = Guid.NewGuid();
            pais.CreatedAt = DateTime.UtcNow;

            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPais), new { id = pais.Id }, pais);
        }

        // PUT: api/paises/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(Guid id, Pais pais)
        {
            if (id != pais.Id)
                return BadRequest();

            pais.ModifiedAt = DateTime.UtcNow;
            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Paises.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/paises/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(Guid id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
                return NotFound();

            _context.Paises.Remove(pais);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
