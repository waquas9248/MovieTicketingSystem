using Dapper;
using System.Data.SqlClient;
using Theater.DBModels;

namespace Theater.Repository;

public class MovieChainRepository: IMovieChainRepository
{
    public async Task<IEnumerable<MovieChainDB>> GetMovieChains()
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        return await connection.QueryAsync<MovieChainDB>("select * from MOVIE_CHAIN");
    }
}
