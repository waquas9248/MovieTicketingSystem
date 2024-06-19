using Theater.DBModels;
using Theater.Repository;
using Theater.ViewModels;

namespace Theater.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        this.reviewRepository = reviewRepository;
    }

    public async Task<List<ReviewMovie>> GetMoviesForReview()
    {
        return await reviewRepository.GetMovies();
    }

    public async Task<List<MovieReview>> GetReviewsForMovie(int movieId)
    {
        return await reviewRepository.GetReviewsForMovie(movieId);
    }

    public async Task<Movie> GetMovie(int movieId)
    {
        return await reviewRepository.GetMovie(movieId);
    }
}
