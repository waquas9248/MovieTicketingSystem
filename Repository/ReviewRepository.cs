using Dapper;
using System.Data.SqlClient;
using Theater.DBModels;
using Theater.ViewModels;

namespace Theater.Repository;

public class ReviewRepository : IReviewRepository
{
    public async Task<List<ReviewMovie>> GetMovies()
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var movies = await connection.QueryAsync<ReviewMovie>("select MovieId as MovieId, MOVIE.Name as Name, Genre as Genre, RATING.Name as Rating " +
            "from movie MOVIE INNER JOIN genre GENRE ON MOVIE.GenreId = GENRE.GenreId INNER JOIN rating RATING ON RATING.RatingId = MOVIE.RatingId");
        return movies.ToList();
    }

    public async Task<List<MovieReview>> GetReviewsForMovie(int movieId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { MovieId = movieId };
        var movies = await connection.QueryAsync<MovieReview>("select Movie.MovieId as MovieId, REVIEW.[User] as 'User', Review as Review " +
            "from movie MOVIE INNER JOIN REVIEW ON MOVIE.MovieId = REVIEW.MovieId where Movie.MovieId = @MovieId", parameters);
        return movies.ToList();
    }

    public async Task<Movie> GetMovie(int movieId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { MovieId = movieId };
        var movie = await connection.QueryFirstAsync<Movie>(
            "select MovieId, RatingId, GenreId, [Name] from movie MOVIE where MovieId = @MovieId", 
            parameters);
        return movie;
    }
}
