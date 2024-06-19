using Dapper;
using System.Data.SqlClient;
using Theater.DBModels;

namespace Theater.Repository;

public class ShowingRepository : IShowingRepository
{
    public async Task<IEnumerable<ShowingDisplay>> GetShowings(DateTime date)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { ShowingDate = date };
        var query = @"
select 
    ShowingId, CHAIN.Name as Chain, THEATER.Name as TheaterName, THEATER.Address as TheaterAddress, SCREEN.Type as ScreenDesc,  
    SCREENTYPE.Name as ScreenType, MOVIE.Name as MovieName, SHOWING.ShowTime as Showtime, GENRE.Genre as Genre, RATING.NAME as Rating
from showing SHOWING
    INNER JOIN screen SCREEN ON SHOWING.ScreenId = SCREEN.ScreenId
    INNER JOIN screen_type SCREENTYPE ON SCREEN.ScreenTypeId = SCREENTYPE.ScreenTypeId
    INNER JOIN movie MOVIE ON SHOWING.MovieId = MOVIE.MovieId
    INNER JOIN theater THEATER ON THEATER.TheaterId = screen.TheaterId
    INNER JOIN movie_chain CHAIN on THEATER.MovieChainId = CHAIN.MovieChainId
    INNER JOIN rating RATING on RATING.RatingId = MOVIE.RatingId
    INNER JOIN genre GENRE on GENRE.GenreId = MOVIE.GenreId
where CAST(SHOWING.ShowTime AS DATE) = @ShowingDate";
        return await connection.QueryAsync<ShowingDisplay>(query, parameters);
    }

    public async Task<ShowingDisplay> GetShowing(int showingId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { ShowingId = showingId };
        var query = @"
select 
    ShowingId, CHAIN.Name as Chain, THEATER.Name as TheaterName, THEATER.Address as TheaterAddress, SCREEN.Type as ScreenDesc,  
    SCREENTYPE.Name as ScreenType, MOVIE.Name as MovieName, SHOWING.ShowTime as Showtime, GENRE.Genre as Genre, RATING.NAME as Rating
from showing SHOWING
    INNER JOIN screen SCREEN ON SHOWING.ScreenId = SCREEN.ScreenId
    INNER JOIN screen_type SCREENTYPE ON SCREEN.ScreenTypeId = SCREENTYPE.ScreenTypeId
    INNER JOIN movie MOVIE ON SHOWING.MovieId = MOVIE.MovieId
    INNER JOIN theater THEATER ON THEATER.TheaterId = screen.TheaterId
    INNER JOIN movie_chain CHAIN on THEATER.MovieChainId = CHAIN.MovieChainId
    INNER JOIN rating RATING on RATING.RatingId = MOVIE.RatingId
    INNER JOIN genre GENRE on GENRE.GenreId = MOVIE.GenreId
where ShowingId= @ShowingId";
        return await connection.QueryFirstAsync<ShowingDisplay>(query, parameters);
    }
}
