namespace Theater.DBModels;

public class ShowingDisplay
{
    public int ShowingId { get; set; }

    public string Chain { get; set; } = string.Empty;

    public string TheaterName { get; set; } = string.Empty;

    public string TheaterAddress { get; set; } = string.Empty;

    public string ScreenDesc { get; set; } = string.Empty;

    public string ScreenType { get; set; } = string.Empty;

    public string MovieName { get; set; } = string.Empty;

    public DateTime Showtime { get; set; } = DateTime.Now;

    public string Genre { get; set; } = string.Empty;

    public string Rating { get; set; } = string.Empty;
}
