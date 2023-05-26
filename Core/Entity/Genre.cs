using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity;

public class Genre : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string GenreId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}