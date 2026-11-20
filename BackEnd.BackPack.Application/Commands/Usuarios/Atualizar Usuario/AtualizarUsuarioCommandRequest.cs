namespace BackEnd.BackPack.Application.Commands.Usuarios.AtualizarUsuario;

public class AtualizarUsuarioCommandRequest
{
    public string NomeUsuario { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}