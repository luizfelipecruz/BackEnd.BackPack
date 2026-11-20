using BackEnd.BackPack.Application.DTOs;
using BackEnd.BackPack.Application.Exceptions;
using BackEnd.BackPack.Application.Extensions;
using BackEnd.BackPack.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd.BackPack.Infrastructure.Services;

public class AuthHelper : IAuthHelper
{
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    public AuthHelper(IConfiguration configuration,
        RoleManager<IdentityRole<Guid>> roleManager)
    {
        _configuration = configuration;
        _roleManager = roleManager;
    }

    public async Task<UsuarioToken> GenerateToken(UsuarioClaims usuario)
    {
        var claims = new List<Claim>
    {
        new("IdUsuario", usuario.IdUsuario.ToString()),
        new("Admin", usuario.Admin.ToString())
    };

        // Valida se o contexto da história está completo
        if (usuario.IdHistoria.HasValue != !usuario.Role.IsNullOrEmpty())
            throw new ApiException("IdHistoria e Role devem ser informados juntos.");

        // Adiciona contexto da história
        if (usuario.IdHistoria.HasValue)
        {
            claims.Add(new Claim(
                "IdHistoria",
                usuario.IdHistoria.Value.ToString()
            ));

            var role = await _roleManager.FindByNameAsync(usuario.Role!);

            if (role == null)
                throw new InvalidOperationException("Role não encontrada.");

            claims.Add(new Claim(ClaimTypes.Role, role.Name!));

            // Recupera Claims adicionais associados à Role
            var roleClaims = await _roleManager.GetClaimsAsync(role);

            // Evita duplicidade e conflitos com Claims reservados
            var reservedClaims = new[]
            {
            "IdUsuario",
            "IdHistoria",
            "Admin",
            ClaimTypes.Role
        };

            foreach (var claim in roleClaims)
            {
                if (!reservedClaims.Contains(claim.Type) &&
                    !claims.Any(c => c.Type == claim.Type && c.Value == claim.Value))
                {
                    claims.Add(claim);
                }
            }
        }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!)
        );

        var credenciais = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var expiracao = double.Parse(
            _configuration["TokenConfiguration:ExpireHours"]!
        );

        var expiration = DateTime.UtcNow.AddHours(expiracao);

        var token = new JwtSecurityToken(
            issuer: _configuration["TokenConfiguration:Issuer"],
            audience: _configuration["TokenConfiguration:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credenciais
        );

        return new UsuarioToken
        {
            Authenticated = true,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }

}