using Theater.DBModels;

namespace Theater.ViewModels;

public class ReviewSelectViewModel
{
    public List<ReviewMovie> Movies { get; set; } = new List<ReviewMovie>();
}
