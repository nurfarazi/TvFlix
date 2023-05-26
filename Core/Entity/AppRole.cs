using Microsoft.AspNetCore.Identity;

namespace Core.Entity
{
    public class AppRole : IdentityRole
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}