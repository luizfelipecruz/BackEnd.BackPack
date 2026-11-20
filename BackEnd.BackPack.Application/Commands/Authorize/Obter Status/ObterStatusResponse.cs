namespace BackEnd.BackPack.Application.Commands.Authorize.Obter_Status;

public record ObterStatusResponse
{
    public Guid IdUsuario { get; set; }
    public string UserName { get; set; }
    public string NomeHistoria { get; set; }
    public string Role { get; set; }
}