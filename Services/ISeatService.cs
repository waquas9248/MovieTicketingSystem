using Theater.DBModels;

namespace Theater.Services;

public interface ISeatService
{
    Task<IEnumerable<Ticket>> GetSeatsForShowing(int showingId);
}
