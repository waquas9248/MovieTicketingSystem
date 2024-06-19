using Theater.DBModels;
using Theater.Repository;

namespace Theater.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        this.ticketRepository = ticketRepository;
    }

    public async Task<Ticket> GetTicketBySeatAndShowing(int seatId, int showingId)
    {
        return await ticketRepository.GetTicketFromSeatAndShowing(seatId, showingId);
    }

    public async Task<bool> MarkTicketReserved(int ticketId)
    {
        return await ticketRepository.MarkTicketReserved(ticketId);
    }

    public async Task<Ticket> GetTicket(int ticketId)
    {
        return await ticketRepository.GetTicketById(ticketId);
    }
}
