using CleanArchitectureNetCore.Application.Constants;
using CleanArchitectureNetCore.Application.Contracts.Identity;
using CleanArchitectureNetCore.Application.Models.Identity;
using CleanArchitectureNetCore.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitectureNetCore.Identity.Services
{
  public class AuthServices : IAuthService
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSettings _jwtSettings;

    public AuthServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthRespose> Login(AuthRequest request)
    {
      var findUser = await _userManager.FindByEmailAsync(request.Email);

      if (findUser == null)
      {
        throw new Exception($"El usuario con el email ${request.Email}, no existe");
      }

      var response = await _signInManager.PasswordSignInAsync(findUser.UserName, request.Password, false, lockoutOnFailure: false);

      if (!response.Succeeded)
      {
        throw new Exception($"Las credenciales son incorrectas");
      }

      var token = await GenerateToken(findUser);

      var authResponse = new AuthRespose
      {
        Id = findUser.Id,
        Email = findUser.Email,
        UserName = findUser.UserName,
        Token = new JwtSecurityTokenHandler().WriteToken(token)
      };

      return authResponse;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
      var existUserByUsername = await _userManager.FindByNameAsync(request.UserName);

      if (existUserByUsername != null)
      {
        throw new Exception("Ya existe una cuenta con este username");
      }

      var existUserByEmail = await _userManager.FindByEmailAsync(request.Email);

      if (existUserByEmail != null)
      {
        throw new Exception("Ya existe una cuenta con este email");
      }

      var user = new ApplicationUser
      {
        Email = request.Email,
        UserName = request.UserName,
        FirstName = request.FirstName,
        LastName = request.LastName,
        EmailConfirmed = true
      };

      var result = await _userManager.CreateAsync(user, request.Password);

      if (result.Succeeded)
      {
        await _userManager.AddToRoleAsync(user, "regular");

        var token = await GenerateToken(user);

        return new RegistrationResponse
        {
          Email = user.Email,
          Id = user.Id,
          Token = new JwtSecurityTokenHandler().WriteToken(token),
          UserName = user.UserName,
        };
      }

      throw new Exception($"{result.Errors}");
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
      var userClaims = await _userManager.GetClaimsAsync(user);
      var roles = await _userManager.GetRolesAsync(user);

      var roleClaim = new List<Claim>();

      foreach (var role in roles)
      {
        roleClaim.Add(new Claim(ClaimTypes.Role, role));
      }

      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(CustomClaimTypes.UID, user.Id)
      }.Union(userClaims)
        .Union(roleClaim);

      var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
      var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

      var jwtSecurityToken = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
        audience: _jwtSettings.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
        signingCredentials: signingCredentials
      );

      return jwtSecurityToken;
    }
  }
}
