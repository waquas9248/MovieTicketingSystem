using Dapper;
using System.Data.SqlClient;
using Theater.DBModels;

namespace Theater.Repository;

public class UserRepository : IUserRepository
{
    public async Task<Customer> GetCustomer(string email)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var query = "select * from Customer where Email = @Email";
        var parameters = new { Email = email };
        return await connection.QueryFirstOrDefaultAsync<Customer>(query, parameters);
    }

    public async Task<bool> CreateAccount(string email, string password)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var query = "INSERT INTO CUSTOMER(CustomerId,Email,Password) SELECT MAX(customerId) + 1, @Email, @Password FROM CUSTOMER;";
        var parameters = new { Email = email, Password = password };
        var result = await connection.ExecuteAsync(query, parameters);
        return result > 0;
    }
}
