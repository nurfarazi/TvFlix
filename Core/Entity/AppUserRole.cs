using Microsoft.AspNetCore.Identity;

namespace Core.Entity;

public class AppUserRole : IdentityUserRole<string>
{
    public virtual AppUser User { get; set; }
    public virtual AppRole Role { get; set; }
}