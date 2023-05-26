using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Core.Entity;

public class AppUser : IdentityUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string AppUserId { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    
    public string ProfilePicture { get; set; }
    public string Bio { get; set; }
    public string Interests { get; set; }
    public string FavoriteMovies { get; set; }
    public string FavoriteTvShows { get; set; }
    public string FavoriteBooks { get; set; }
    public DateTime LastLogin { get; set; }
    public int NumberOfLogins { get; set; }
    public bool Active { get; set; }
    
    public virtual ICollection<AppUserRole> UserRoles { get; set; }
}