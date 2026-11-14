namespace BackEnd.BackPack.Aplication.Commands.Usuarios.CriarUsuario;

public class CriarUsuarioCommandRequest
{
    public string NomeUsuario { get; set; }
    public string Senha { get; set; }
    public bool Admin { get; set; }
}