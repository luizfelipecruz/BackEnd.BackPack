using Microsoft.AspNetCore.Identity;

namespace BackEnd.BackPack.Domain.Entidades;

public class Usuario : IdentityUser<Guid>
{

    public bool Admin { get; set; }
    public virtual ICollection<Personagem> Personagems { get; set; }
        = new List<Personagem>();

    public virtual ICollection<UsuarioHistoria> Historias { get; set; }
        = new List<UsuarioHistoria>();
}