namespace BackEnd.BackPack.Domain.Entidades;

public class Usuario : EntidadeBase
{
    public string Login { get; set; }
    public string Senha { get; set; }
    public int? Tipo { get; set; }

    public virtual ICollection<Personagem> Personagems { get; set; }
    public virtual ICollection<UsuarioHistoria> Historias { get; set; }
}
