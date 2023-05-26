using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity.Series;

public class Season : BaseContentEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string SeasonId { get; set; }
    
    [Required]
    public string SeriesId { get; set; }
    public Series Series { get; set; }
    
    public ICollection<Episode> Episodes { get; set; }
}