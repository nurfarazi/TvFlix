using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration config;
    private readonly SymmetricSecurityKey key;

    public TokenService(IConfiguration configuration)
    {
        this.config = configuration;
        this.key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Token:Key"] ?? string.Empty));
    }

    public string CreateTokenAsync(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim("UserName", user.UserName),
        };

        claims.AddRange(user.UserRoles.Select(role => new Claim(ClaimTypes.Role, role.Role.Name)));
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));

        var credentials = new SigningCredentials(this.key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(Convert.ToDouble(this.config["Token:Expires"])),
            SigningCredentials = credentials,
            Issuer = this.config["Token:Issuer"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}