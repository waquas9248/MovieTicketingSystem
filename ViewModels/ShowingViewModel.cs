using Theater.DBModels;

namespace Theater.ViewModels;

public class ShowingViewModel
{
    public IEnumerable<ShowingDisplay> Showings { get; set; } = new List<ShowingDisplay>();

    public int SelectedShowingId { get; set; }
}
