using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infrastructure.DbContexts;

namespace BackEnd.BackPack.Infrastructure.Repositories;

public class PersonagemRepository : RepositoryAsync<Personagem>, IPersonagemRepository
{
    public PersonagemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
