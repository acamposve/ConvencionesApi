using Dapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Contratos.Queries;

public record GetContratoByIdQuery(Guid Id) : IRequest<Contrato?>;

public class GetContratoByIdQueryHandler : IRequestHandler<GetContratoByIdQuery, Contrato?>
{
    private readonly IDapperConnectionFactory _factory;

    public GetContratoByIdQueryHandler(IDapperConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<Contrato?> Handle(GetContratoByIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = _factory.CreateConnection();
        var sql = @"SELECT * FROM contratos WHERE id = @Id";
        return await connection.QueryFirstOrDefaultAsync<Contrato>(sql, new { request.Id });
    }
}
