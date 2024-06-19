using Theater.DBModels;

namespace Theater.Services;

public interface ITicketService
{
    Task<Ticket> GetTicketBySeatAndShowing(int seatId, int showingId);

    Task<bool> MarkTicketReserved(int ticketId);

    Task<Ticket> GetTicket(int ticketId);
}
