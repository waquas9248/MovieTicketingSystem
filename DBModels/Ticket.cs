namespace Theater.DBModels;

public class Ticket
{
    public int TicketId { get; set; }

    public int SeatId { get; set; }

    public string Type { get; set; } = string.Empty;

    public decimal Price { get; set; }
}
