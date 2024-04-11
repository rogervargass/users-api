using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersApi.Models;

namespace UsersApi.Services;

public class TokenService(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public string GenerateToken(User user)
    {
        Claim[] claims =
        [
            new("username", user.UserName),
            new("id", user.Id),
            new(ClaimTypes.DateOfBirth, user.BirthDate.ToString())
        ];

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

        SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}