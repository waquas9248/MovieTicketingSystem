using Theater.DBModels;
using Theater.ViewModels;

namespace Theater.Repository;

public interface IReviewRepository
{
    Task<List<ReviewMovie>> GetMovies();

    Task<List<MovieReview>> GetReviewsForMovie(int movieId);

    Task<Movie> GetMovie(int movieId);
}
