using Theater.DBModels;
using Theater.ViewModels;

namespace Theater.Services;

public interface IReviewService
{
    Task<List<ReviewMovie>> GetMoviesForReview();

    Task<List<MovieReview>> GetReviewsForMovie(int movieId);

    Task<Movie> GetMovie(int movieId);
}
