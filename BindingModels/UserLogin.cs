using System.ComponentModel.DataAnnotations;

namespace Theater.ViewModels;

public class UserLogin
{
    [Display(Name = "Your email")]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
