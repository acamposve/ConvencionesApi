using Dapper;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Contratos.Queries;

public record GetContratosQuery : IRequest<IEnumerable<Contrato>>;

public class GetContratosQueryHandler : IRequestHandler<GetContratosQuery, IEnumerable<Contrato>>
{
    private readonly IDapperConnectionFactory _factory;

    public GetContratosQueryHandler(IDapperConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Contrato>> Handle(GetContratosQuery request, CancellationToken cancellationToken)
    {
        using var connection = _factory.CreateConnection();
        var sql = @"SELECT id, pdf_auto_acta, fecha_de_inicio, fecha_de_termino, duracion, 
                           ambito_aplicacion, codigo_empresa, status_publicacion, createdby, 
                           createdat, modifiedby, modifiedat
                    FROM contratos";
        return await connection.QueryAsync<Contrato>(sql);
    }
}