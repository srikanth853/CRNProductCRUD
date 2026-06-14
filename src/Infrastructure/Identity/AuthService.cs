using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AuthResponse Login(LoginRequest request)
    {
        if (request.UserName != "admin" || request.Password != "Admin@123")
            throw new UnauthorizedAccessException("Invalid username or password");

        return new AuthResponse
        {
            AccessToken = GenerateToken(request.UserName),
            RefreshToken = Guid.NewGuid().ToString()
        };
    }

    private string GenerateToken(string userName)
    {
        var key = _configuration["Jwt:Key"] ?? "ThisIsMySecretKeyForCRNAssessment12345";
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}