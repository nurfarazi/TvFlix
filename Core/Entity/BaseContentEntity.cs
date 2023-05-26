namespace Core.Entity;

public class BaseContentEntity : BaseEntity
{
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public string Cast { get; set; }
    public int RunTime { get; set; }
    public string Rating { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Trailer { get; set; }
    public double UserRatings { get; set; }
    public int NumberOfRatings { get; set; }
    public double Popularity { get; set; }
    public string Keywords { get; set; }
}