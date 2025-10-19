using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Contratos.Commands;

public record UpdateContratoCommand(
    Guid Id,
    string PdfAutoActa,
    DateTime? FechaDeInicio,
    DateTime? FechaDeTermino,
    string Duracion,
    string AmbitoAplicacion,
    int CodigoEmpresa,
    string ModifiedBy
) : IRequest<Unit>; // 👈 Aquí está la diferencia

public class UpdateContratoCommandHandler : IRequestHandler<UpdateContratoCommand, Unit> // 👈 también aquí
{
    private readonly ApplicationDbContext _context;

    public UpdateContratoCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateContratoCommand request, CancellationToken cancellationToken)
    {
        var contrato = await _context.Contratos
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (contrato is null)
            throw new KeyNotFoundException("Contrato no encontrado.");

        contrato.PdfAutoActa = request.PdfAutoActa;
        contrato.FechaDeInicio = request.FechaDeInicio;
        contrato.FechaDeTermino = request.FechaDeTermino;
        contrato.Duracion = request.Duracion;
        contrato.AmbitoAplicacion = request.AmbitoAplicacion;
        contrato.CodigoEmpresa = request.CodigoEmpresa;
        contrato.ModifiedBy = request.ModifiedBy;
        contrato.ModifiedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value; // 👈 devuelve Unit.Value (equivalente a "void")
    }
}