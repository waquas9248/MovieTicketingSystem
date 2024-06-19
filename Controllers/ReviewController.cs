using Microsoft.AspNetCore.Mvc;
using Theater.Services;
using Theater.ViewModels;

namespace Theater.Controllers;

public class ReviewController : Controller
{
    private readonly IReviewService reviewService;

    public ReviewController(IReviewService reviewService)
    {
        this.reviewService = reviewService;
    }

    [HttpGet]
    [Route("Review/ReviewSelect")]
    public async Task<IActionResult> ReviewSelect()
    {
        var movies = await reviewService.GetMoviesForReview();
        var viewModel = new ReviewSelectViewModel { Movies = movies };
        return View(viewModel);
    }

    [HttpGet]
    [Route("Review/Review/{movieId:int}")]
    public async Task<IActionResult> Review(int movieId)
    {
        var movieReviews = await reviewService.GetReviewsForMovie(movieId);
        var movie = await reviewService.GetMovie(movieId);
        var movieReviewViewModel = new MovieReviewViewModel { Movie = movie, MovieReviews = movieReviews };
        return View(movieReviewViewModel);
    }
}
