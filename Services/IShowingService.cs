using Theater.DBModels;

namespace Theater.Services;

public interface IShowingService
{
    Task<IEnumerable<ShowingDisplay>> GetShowings(DateTime date);

    Task<ShowingDisplay> GetShowing(int showingId);
}
