using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DoctorAppointmentService.Api.Security;

public class JwtTokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken()
    {
        var key = _configuration["Jwt:Key"] ?? throw new ArgumentNullException("JwtSettings:Key is missing!");
        var issuer = _configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("JwtSettings:Issuer is missing!");
        var audience = _configuration["Jwt:Audience"] ?? throw new ArgumentNullException("JwtSettings:Audience is missing!");
        var durationInMinutes = Convert.ToInt32(_configuration["Jwt:DurationInMinutes"]);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new List<Claim>(),
            expires: DateTime.Now.AddMinutes(durationInMinutes),
            signingCredentials: credentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(token);

        return tokenString;
    }


}
