using Theater.DBModels;
using Theater.Repository;

namespace Theater.Services;

public class ShowingService : IShowingService
{
    private readonly IShowingRepository showingRepository;

    public ShowingService(IShowingRepository showingRepository)
    {
        this.showingRepository = showingRepository;
    }

    public async Task<IEnumerable<ShowingDisplay>> GetShowings(DateTime date)
    {
        return await showingRepository.GetShowings(date);
    }

    public async Task<ShowingDisplay> GetShowing(int showingId)
    {
        return await showingRepository.GetShowing(showingId);
    }
}
