using Dapper;
using System.Data.SqlClient;
using Theater.DBModels;

namespace Theater.Repository;

public class ConcessionRepository: IConcessionRepository
{
    public async Task<IEnumerable<Concession>> GetConcessions()
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        return await connection.QueryAsync<Concession>("select * from CONCESSION where InventoryQuantity > 0");
    }
}
