using Theater.DBModels;

namespace Theater.Services;

public interface IUserService
{
    Task<bool> Login(string email, string password);

    Task<bool> CreateAccount(string email, string password);

    Task<Customer?> GetAccount(string email);
}
