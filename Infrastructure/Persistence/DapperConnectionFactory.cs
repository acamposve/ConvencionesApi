using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Persistence;

public interface IDapperConnectionFactory
{
    IDbConnection CreateConnection();
}

public class DapperConnectionFactory : IDapperConnectionFactory
{
    private readonly IConfiguration _configuration;

    public DapperConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        return new SqlConnection(connectionString);
    }
}
