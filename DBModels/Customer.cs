namespace Theater.DBModels;

public class Customer
{
    public int CustomerId { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
