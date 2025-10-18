using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContratosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/contratos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratos()
        {
            return await _context.Contratos.ToListAsync();
        }

        // GET: api/contratos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(Guid id)
        {
            var contrato = await _context.Contratos.FindAsync(id);

            if (contrato == null)
                return NotFound();

            return contrato;
        }

        // POST: api/contratos
        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
        {
            contrato.Id = Guid.NewGuid();
            contrato.CreatedAt = DateTime.UtcNow;

            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContrato), new { id = contrato.Id }, contrato);
        }

        // PUT: api/contratos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato(Guid id, Contrato contrato)
        {
            if (id != contrato.Id)
                return BadRequest();

            contrato.ModifiedAt = DateTime.UtcNow;
            _context.Entry(contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Contratos.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/contratos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrato(Guid id)
        {
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
                return NotFound();

            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
