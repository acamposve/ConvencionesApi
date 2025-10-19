using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Paises.Commands;

public record CreatePaisCommand(string Name, string? CreatedBy) : IRequest<Guid>;

public class CreatePaisCommandHandler : IRequestHandler<CreatePaisCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    public CreatePaisCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePaisCommand request, CancellationToken cancellationToken)
    {
        var pais = new Pais
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Paises.Add(pais);
        await _context.SaveChangesAsync(cancellationToken);

        return pais.Id;
    }
}