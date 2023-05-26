using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity;

public class UserActivity : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string UserActivityId { get; set; }

    [Required]
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    
}