namespace Theater.DBModels;

public class Movie
{
    public int MovieId { get; set; }

    public int RatingId { get; set; }

    public int GenreId { get; set; }

    public string Name { get; set; } = string.Empty;
}
