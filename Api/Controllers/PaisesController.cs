using Application.Paises.Commands;
using Application.Paises.Queries;
using Domain.Entities;
using MediatR;
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
        private readonly IMediator _mediator;

        public PaisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/paises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
            var result = await _mediator.Send(new GetAllPaisesQuery());
            return Ok(result);
        }

        // GET: api/paises/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(Guid id)
        {
            var result = await _mediator.Send(new GetPaisByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: api/paises
        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePais([FromBody] CreatePaisCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPais), new { id }, new { id });
        }

        // PUT: api/paises/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePais(Guid id, [FromBody] UpdatePaisCommand command)
        {
            if (id != command.Id)
                return BadRequest("El ID no coincide con el cuerpo del request.");

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/paises/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(Guid id)
        {
            await _mediator.Send(new DeletePaisCommand(id));
            return NoContent();
        }


    }
}
