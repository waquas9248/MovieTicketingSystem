namespace Theater.ViewModels;

public class ConcessionLineOnOrder
{
    public string ConcessionName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal ConcessionPrice { get; set; }

    public decimal Total { get; set; }
}
