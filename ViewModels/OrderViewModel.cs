using Theater.DBModels;

namespace Theater.ViewModels;

public class OrderViewModel
{
    public List<Concession> Concessions{ get; set; } = new List<Concession>();

    public Ticket? Ticket { get; set; }

    public List<ConcessionLineOnOrder> ConcessionLines { get; set; } = new List<ConcessionLineOnOrder>();

    public decimal OrderTotal { get; set; }

    public int OrderId { get; set; }

    public ShowingDisplay? ShowingDisplay { get; set; }
}
