namespace Theater.DBModels;

public class TicketLineItem
{
    public int TicketLineItemId { get; set; }

    public int TicketId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }
}
