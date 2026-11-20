using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.BackPack.Infrastructure.Repositories;

public class HistoriaRepository : RepositoryAsync<Historia>, IHistoriaRepository
{
    public HistoriaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AnyByName(string nome)
        => await Query().AnyAsync(h => h.Nome == nome);
}
