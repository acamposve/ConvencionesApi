using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Paises.Queries;

public record GetPaisByIdQuery(Guid Id) : IRequest<Pais?>;

public class GetPaisByIdQueryHandler : IRequestHandler<GetPaisByIdQuery, Pais?>
{
    private readonly ApplicationDbContext _context;

    public GetPaisByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Pais?> Handle(GetPaisByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Paises
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    }
}
