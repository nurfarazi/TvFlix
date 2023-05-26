using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity.Series;

public class Series : BaseContentEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string SeriesId { get; set; }
    public bool Ended { get; set; }
    public string Network { get; set; }
    public string Country { get; set; }
    public string Language { get; set; }
    public string Awards { get; set; }
    public string TrailerUrl { get; set; }
    public int NumberOfSeasons { get; set; }
    public int NumberOfEpisodes { get; set; }
    public int NumberOfSeasonsWatched { get; set; }
    public int NumberOfEpisodesWatched { get; set; }
    
    public ICollection<Season> Seasons { get; set; }
}