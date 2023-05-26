using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity.Series;

public class Episode : BaseContentEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string EpisodeId { get; set; }

    public string VideoUrl { get; set; }
    public string AudioUrl { get; set; }
    public int Duration { get; set; }
    public string Size { get; set; }
    public string Quality { get; set; }
    public string Language { get; set; }
    public string Subtitle { get; set; }
    public string SubtitleLanguage { get; set; }
    public string SubtitleType { get; set; }
    public string SubtitleSize { get; set; }
    public string SubtitleUrl { get; set; }
    public string SubtitleDownloadUrl { get; set; }
    public string SubtitleDownloadUrl2 { get; set; }
    public string SubtitleDownloadUrl3 { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EpisodeNumber { get; set; }
    public int SeasonNumber { get; set; }
    public bool IsReleased { get; set; }

    [Required] 
    public string SeriesId { get; set; }
    public Series Series { get; set; }
    
    [Required]
    public string SeasonId { get; set; }
    public Season Season { get; set; }
}