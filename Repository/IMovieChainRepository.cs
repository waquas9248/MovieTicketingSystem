using Theater.DBModels;

namespace Theater.Repository;

public interface IMovieChainRepository
{
    Task<IEnumerable<MovieChainDB>> GetMovieChains();
}
