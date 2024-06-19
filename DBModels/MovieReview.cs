namespace Theater.DBModels;

public class MovieReview
{
    public int MovieId { get; set; }

    public string User { get; set; } = string.Empty;

    public string Review { get; set; } = string.Empty;
}
