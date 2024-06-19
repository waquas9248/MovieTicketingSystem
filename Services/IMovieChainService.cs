namespace Theater.Services;

public interface IMovieChainService
{
    Task<IEnumerable<DBModels.MovieChainDB>> GetMovieChains();
}
