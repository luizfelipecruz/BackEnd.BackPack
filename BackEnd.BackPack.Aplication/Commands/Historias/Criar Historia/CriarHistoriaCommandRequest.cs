namespace BackEnd.BackPack.Aplication.Commands.Historias.Criar_Historia;

public class CriarHistoriaCommandRequest
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public Guid IdMestre { get; set; }
}