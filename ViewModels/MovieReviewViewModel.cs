using Theater.DBModels;

namespace Theater.ViewModels;

public class MovieReviewViewModel
{
    public Movie? Movie { get; set; }

    public List<MovieReview> MovieReviews { get; set; } = new List<MovieReview>();
}
