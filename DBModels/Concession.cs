namespace Theater.DBModels;

public class Concession
{
    public int ConcessionId { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; } = string.Empty;

    public int InventoryQuantity { get; set; }
}
