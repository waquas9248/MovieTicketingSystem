using Theater.DBModels;

namespace Theater.Repository;

public interface ITicketRepository
{
    Task<Ticket> GetTicketFromSeatAndShowing(int seatId, int showingId);

    Task<bool> MarkTicketReserved(int ticketId);

    Task<Ticket> GetTicketById(int ticketId);
}
