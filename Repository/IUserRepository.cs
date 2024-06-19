using Theater.DBModels;

namespace Theater.Repository;

public interface IUserRepository
{
    Task<Customer> GetCustomer(string email);

    Task<bool> CreateAccount(string email, string password);
}
