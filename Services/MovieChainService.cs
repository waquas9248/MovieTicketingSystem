using Theater.Repository;

namespace Theater.Services;

public class MovieChainService : IMovieChainService
{
    private readonly IMovieChainRepository movieChainRepository;

    public MovieChainService(IMovieChainRepository movieChainRepository)
    {
        this.movieChainRepository = movieChainRepository;
    }

    public async Task<IEnumerable<DBModels.MovieChainDB>> GetMovieChains()
    {
        return await movieChainRepository.GetMovieChains();
    }
}
