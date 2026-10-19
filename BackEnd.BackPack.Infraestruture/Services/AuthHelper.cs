using BackEnd.BackPack.Aplication.Commands.Authorize;
using BackEnd.BackPack.Aplication.Extesnions;
using BackEnd.BackPack.Aplication.Services;
using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Enuns;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static BackEnd.BackPack.Aplication.Extesnions.IntExtensions;

namespace BackEnd.BackPack.Infraestruture.Services;

public class AuthHelper : IAuthHelper
{
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public AuthHelper(IConfiguration configuration,
        RoleManager<IdentityRole<int>> roleManager)
    {
        _configuration = configuration;
        _roleManager = roleManager;
    }

    public async Task<UsuarioToken> GenerateToken(Usuario usuario)
    {
        var usuarioHistoria = usuario.Historias.FirstOrDefault();

        if (usuarioHistoria == null)
            throw new Exception("Usuário não está vinculado a nenhuma história.");

        var enumName = ((int)usuarioHistoria.EnumRole).GetEnumDescription<EnumRole>();

        // Busca a Role no Identity
        var role = await _roleManager.FindByNameAsync(enumName);

        if (role == null)
            throw new Exception($"Role '{enumName}' não encontrada.");

        // Busca as claims adicionais da Role
        var roleClaims = await _roleManager.GetClaimsAsync(role);

        var claims = new List<Claim>

    {
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new("IdUsuario", usuario.Id.ToString()),
        new("IdHistoria", usuarioHistoria.IdHistoria.ToString()),
        new(ClaimTypes.Role, enumName)
    };

        // Adiciona as claims configuradas na Role
        claims.AddRange(roleClaims);

        // Chave utilizada para assinar o JWT
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:key"]!
            )
        );

        var credenciais = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        // Tempo de expiração
        var expiracao = double.Parse(
            _configuration["TokenConfiguration:ExpireHours"]!
        );

        var expiration = DateTime.UtcNow.AddHours(expiracao);

        // Cria o token
        var token = new JwtSecurityToken(
            issuer: _configuration["TokenConfiguration:Issuer"],
            audience: _configuration["TokenConfiguration:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credenciais
        );

        // Retorna o token
        return new UsuarioToken
        {
            Authenticated = true,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}