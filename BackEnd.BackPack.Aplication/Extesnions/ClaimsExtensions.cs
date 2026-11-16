using BackEnd.BackPack.Aplication.DTOs;
using System.Security.Claims;

namespace BackEnd.BackPack.Aplication.Extesnions;

public static class ClaimsExtensions
{
    public static UsuarioClaims GetClaims(this ClaimsPrincipal user)
    {
        return new UsuarioClaims
        {
            IdUsuario = Guid.Parse(
                user.FindFirst("IdUsuario")!.Value
            ),

            Admin = bool.Parse(
                user.FindFirst("Admin")!.Value
            ),

            IdHistoria = Guid.TryParse(
                user.FindFirst("IdHistoria")?.Value,
                out var idHistoria
            ) ? idHistoria : null,

            Role = user.FindFirst(ClaimTypes.Role)?.Value
        };
    }
}
