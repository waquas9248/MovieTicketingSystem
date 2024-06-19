using Theater.DBModels;
using Theater.Repository;

namespace Theater.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<bool> Login(string email, string password)
    {
        var customer = await userRepository.GetCustomer(email);
        return (customer?.Password ?? string.Empty) == password;
    }

    public async Task<bool> CreateAccount(string email, string password)
    {
        var accountForEmail = await GetAccount(email);
        if (accountForEmail != null)
        {
            return false;
        }

        return await userRepository.CreateAccount(email, password);
    }

    public async Task<Customer?> GetAccount(string email)
    {
        return await userRepository.GetCustomer(email);
    }
}
