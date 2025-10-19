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

public record GetAllPaisesQuery() : IRequest<IEnumerable<Pais>>;

public class GetAllPaisesQueryHandler : IRequestHandler<GetAllPaisesQuery, IEnumerable<Pais>>
{
    private readonly ApplicationDbContext _context;

    public GetAllPaisesQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pais>> Handle(GetAllPaisesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Paises.AsNoTracking().ToListAsync(cancellationToken);
    }
}
