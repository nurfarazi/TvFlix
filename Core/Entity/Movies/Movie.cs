using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity.Movies;

public class Movie : BaseContentEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string MovieId { get; set; }
}