using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TMS.Domain.Entities;
using TMS.Service.Common.Application.Authentication;

namespace TMS.Application.Common.Implementation.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<UserModel> _userManager;
    private readonly SymmetricSecurityKey _jwtKey;

    public JwtTokenGenerator(IConfiguration configuration,  UserManager<UserModel> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    }

    public async Task<string> GenerateToken(UserModel user)
    {
        var userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,  user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
        };
        
        var roles = await _userManager.GetRolesAsync(user);
        userClaims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        
        var credentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(userClaims),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpiresInMinutes"])),
            SigningCredentials = credentials,
            Issuer = _configuration["Jwt:Issuer"],
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}