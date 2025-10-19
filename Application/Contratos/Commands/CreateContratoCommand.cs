using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Contratos.Commands;
public record CreateContratoCommand(
    string PdfAutoActa,
    DateTime? FechaDeInicio,
    DateTime? FechaDeTermino,
    string Duracion,
    string AmbitoAplicacion,
    int CodigoEmpresa,
    string CreatedBy
) : IRequest<Guid>;

public class CreateContratoCommandHandler : IRequestHandler<CreateContratoCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    public CreateContratoCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateContratoCommand request, CancellationToken cancellationToken)
    {
        var contrato = new Contrato
        {
            Id = Guid.NewGuid(),
            PdfAutoActa = request.PdfAutoActa,
            FechaDeInicio = request.FechaDeInicio,
            FechaDeTermino = request.FechaDeTermino,
            Duracion = request.Duracion,
            AmbitoAplicacion = request.AmbitoAplicacion,
            CodigoEmpresa = request.CodigoEmpresa,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Contratos.Add(contrato);
        await _context.SaveChangesAsync(cancellationToken);
        return contrato.Id;
    }
}