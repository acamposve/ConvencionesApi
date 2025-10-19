using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Paises.Commands;

public record UpdatePaisCommand(Guid Id, string Name, string? ModifiedBy) : IRequest<Unit>;

public class UpdatePaisCommandHandler : IRequestHandler<UpdatePaisCommand, Unit>
{
    private readonly ApplicationDbContext _context;

    public UpdatePaisCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdatePaisCommand request, CancellationToken cancellationToken)
    {
        var pais = await _context.Paises.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (pais is null)
            throw new KeyNotFoundException("País no encontrado.");

        pais.Name = request.Name;
        pais.ModifiedBy = request.ModifiedBy;
        pais.ModifiedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}