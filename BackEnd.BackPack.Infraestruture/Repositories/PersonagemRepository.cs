using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;

namespace BackEnd.BackPack.Infraestruture.Repositories;

public class PersonagemRepository : RepositoryAsync<Personagem>, IPersonagemRepository
{
    public PersonagemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
