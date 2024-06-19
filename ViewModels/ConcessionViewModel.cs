using Theater.DBModels;

namespace Theater.ViewModels;

public class ConcessionViewModel
{
    public IEnumerable<Concession> Concessions { get; set; } = new List<Concession>();
}
