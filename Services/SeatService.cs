using Theater.DBModels;
using Theater.Repository;

namespace Theater.Services;

public class SeatService : ISeatService
{
    private readonly ISeatRepository seatRepository;

    public SeatService(ISeatRepository seatRepository)
    {
        this.seatRepository = seatRepository;
    }

    public async Task<IEnumerable<Ticket>> GetSeatsForShowing(int showingId)
    {
        return await seatRepository.GetOpenSeatsForShowing(showingId);
    }
}
