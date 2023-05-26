using Core.Entity;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        string CreateTokenAsync(AppUser user);
    }
}