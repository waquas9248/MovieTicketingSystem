namespace Theater.DBModels;

public class ConcessionLineItem
{
    public int ConcessionLineItemId { get; set; }

    public int ConcessionId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }
}
