namespace BackEnd.BackPack.Domain.Entidades;

public class Personagem : EntidadeBase
{
    public int Nivel { get; set; }
    public decimal Experiencia { get; set; }
    public decimal PesoMaximo { get; set; }
}
