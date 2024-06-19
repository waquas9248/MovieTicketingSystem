using Theater.DBModels;

namespace Theater.Repository;

public interface IShowingRepository
{
    Task<IEnumerable<ShowingDisplay>> GetShowings(DateTime date);

    Task<ShowingDisplay> GetShowing(int showingId);
}
