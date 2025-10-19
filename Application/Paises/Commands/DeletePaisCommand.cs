using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Paises.Commands;

public record DeletePaisCommand(Guid Id) : IRequest<Unit>;

public class DeletePaisCommandHandler : IRequestHandler<DeletePaisCommand, Unit>
{
    private readonly ApplicationDbContext _context;

    public DeletePaisCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePaisCommand request, CancellationToken cancellationToken)
    {
        var pais = await _context.Paises.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (pais is null)
            throw new KeyNotFoundException("País no encontrado.");

        _context.Paises.Remove(pais);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
