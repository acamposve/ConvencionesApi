using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Contratos.Commands;



public record DeleteContratoCommand(Guid Id) : IRequest<Unit>; // 👈 Cambiado a IRequest<Unit>

public class DeleteContratoCommandHandler : IRequestHandler<DeleteContratoCommand, Unit> // 👈 Agregamos Unit
{
    private readonly ApplicationDbContext _context;

    public DeleteContratoCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteContratoCommand request, CancellationToken cancellationToken)
    {
        var contrato = await _context.Contratos.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (contrato is null)
            throw new KeyNotFoundException("Contrato no encontrado.");

        _context.Contratos.Remove(contrato);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value; // 👈 devolvemos Unit.Value
    }
}
