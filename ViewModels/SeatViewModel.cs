using Theater.DBModels;

namespace Theater.ViewModels;

public class SeatTicketViewModel
{
    public IEnumerable<Ticket> Tickets { get; set; } = new List<Ticket>();

    public int SelectedSeatId { get; set; }
}
