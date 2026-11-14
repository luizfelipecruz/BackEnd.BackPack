using BackEnd.BackPack.Domain.Entidades;

namespace BackEnd.BackPack.Domain.Repositories;

public interface IHistoriaRepository : IRepositoryAsync<Historia>
{
    Task<bool> AnyByName(string nome);
}
