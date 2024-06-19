using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Theater.ViewModels;

public class DateSelection
{
    [Display(Name = "Date for movie")]
    [Required]
    [BindProperty, DataType(DataType.Date)]
    public DateTime DateTime { get; set; }
}
