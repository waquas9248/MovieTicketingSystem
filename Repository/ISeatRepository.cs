using Theater.DBModels;

namespace Theater.Repository;

public interface ISeatRepository
{
    Task<IEnumerable<Ticket>> GetOpenSeatsForShowing(int showingId);
}
