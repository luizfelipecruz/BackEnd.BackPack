
using BackEnd.BackPack.Domain.Entidades;
using BackEnd.BackPack.Domain.Enuns;
using BackEnd.BackPack.Infraestruture.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.BackPack.Infraestruture.Seeds;

public static class ItemSeeder
{
    public static async Task SeedAsync<TContext>(TContext dbContext)
        where TContext : ApplicationDbContext
    {
        // Busca os nomes dos itens globais já existentes
        var itensExistentes = await dbContext.Set<Item>()
            .Where(x => x.IdHistoria == null)
            .Select(x => x.Nome)
            .ToListAsync();

        var nomesExistentes = new HashSet<string>(
            itensExistentes,
            StringComparer.OrdinalIgnoreCase);

        var itens = new List<Item>
        {
            // ARMAS
            new()
            {
                Nome = "Espada Curta",
                Descricao = "Uma espada simples, leve e versátil.",
                Peso = 1.5m,
                Durabilidade = 100,
                Tamanho = 0.6m,
                Dureza = 6,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Arma,
                IdHistoria = null
            },
            new()
            {
                Nome = "Adaga",
                Descricao = "Uma pequena lâmina utilizada em combate próximo.",
                Peso = 0.5m,
                Durabilidade = 80,
                Tamanho = 0.3m,
                Dureza = 5,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Arma,
                IdHistoria = null
            },
            new()
            {
                Nome = "Arco Curto",
                Descricao = "Arma de disparo que utiliza flechas.",
                Peso = 1,
                Durabilidade = 90,
                Tamanho = 1.2m,
                Dureza = 4,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Arma,
                IdHistoria = null
            },
            new()
            {
                Nome = "Cajado de Madeira",
                Descricao = "Um cajado simples, utilizado como apoio ou arma.",
                Peso = 2,
                Durabilidade = 70,
                Tamanho = 1.8m,
                Dureza = 3,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Arma,
                IdHistoria = null
            },

            // ARMADURAS
            new()
            {
                Nome = "Armadura de Couro",
                Descricao = "Proteção leve feita de couro resistente.",
                Peso = 5,
                Durabilidade = 100,
                Tamanho = 1,
                Dureza = 4,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Armadura,
                IdHistoria = null
            },
            new()
            {
                Nome = "Escudo de Madeira",
                Descricao = "Escudo simples feito de madeira reforçada.",
                Peso = 3,
                Durabilidade = 100,
                Tamanho = 0.8m,
                Dureza = 5,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Armadura,
                IdHistoria = null
            },
            new()
            {
                Nome = "Elmo de Ferro",
                Descricao = "Proteção metálica para a cabeça.",
                Peso = 2,
                Durabilidade = 120,
                Tamanho = 0.3m,
                Dureza = 8,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Armadura,
                IdHistoria = null
            },

            // FERRAMENTAS
            new()
            {
                Nome = "Corda",
                Descricao = "Corda resistente utilizada para escaladas e amarrações.",
                Peso = 2,
                Durabilidade = 80,
                Tamanho = 10,
                Dureza = 1,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Ferramenta,
                IdHistoria = null
            },
            new()
            {
                Nome = "Tocha",
                Descricao = "Fonte de iluminação portátil.",
                Peso = 0.5m,
                Durabilidade = 10,
                Tamanho = 0.5m,
                Dureza = 1,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Ferramenta,
                IdHistoria = null
            },
            new()
            {
                Nome = "Mochila",
                Descricao = "Bolsa resistente utilizada para transportar equipamentos.",
                Peso = 1,
                Durabilidade = 100,
                Tamanho = 0.8m,
                Dureza = 2,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Bolsa,
                IdHistoria = null
            },
            new()
            {
                Nome = "Kit de Ferramentas",
                Descricao = "Conjunto básico de ferramentas para reparos.",
                Peso = 2,
                Durabilidade = 100,
                Tamanho = 0.4m,
                Dureza = 5,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Ferramenta,
                IdHistoria = null
            },

            // CONSUMÍVEIS
            new()
            {
                Nome = "Poção de Cura",
                Descricao = "Poção simples capaz de restaurar a saúde.",
                Peso = 0.3m,
                Durabilidade = 1,
                Tamanho = 0.2m,
                Dureza = 1,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Consumivel,
                IdHistoria = null
            },
            new()
            {
                Nome = "Antídoto",
                Descricao = "Preparado utilizado para combater venenos.",
                Peso = 0.3m,
                Durabilidade = 1,
                Tamanho = 0.2m,
                Dureza = 1,
                Raridade = EnumRaridade.Incomum,
                Tipo = EnumTipoItem.Consumivel,
                IdHistoria = null
            },
            new()
            {
                Nome = "Ração de Viagem",
                Descricao = "Alimento preparado para longas jornadas.",
                Peso = 0.5m,
                Durabilidade = 1,
                Tamanho = 0.2m,
                Dureza = 1,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Consumivel,
                IdHistoria = null
            },

            // MATERIAIS
            new()
            {
                Nome = "Madeira",
                Descricao = "Material básico utilizado em construções e fabricação.",
                Peso = 1,
                Durabilidade = 100,
                Tamanho = 1,
                Dureza = 3,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Material,
                IdHistoria = null
            },
            new()
            {
                Nome = "Ferro",
                Descricao = "Metal utilizado na fabricação de armas e armaduras.",
                Peso = 2,
                Durabilidade = 100,
                Tamanho = 0.3m,
                Dureza = 8,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Material,
                IdHistoria = null
            },
            new()
            {
                Nome = "Couro",
                Descricao = "Material resistente utilizado na fabricação de equipamentos.",
                Peso = 0.5m,
                Durabilidade = 80,
                Tamanho = 0.5m,
                Dureza = 2,
                Raridade = EnumRaridade.Comum,
                Tipo = EnumTipoItem.Material,
                IdHistoria = null
            },
            new()
            {
                Nome = "Cristal Mágico",
                Descricao = "Cristal com propriedades mágicas desconhecidas.",
                Peso = 0.2m,
                Durabilidade = 100,
                Tamanho = 0.1m,
                Dureza = 7,
                Raridade = EnumRaridade.Raro,
                Tipo = EnumTipoItem.Material,
                IdHistoria = null
            }
        };

        // Adiciona somente itens que ainda não existem
        var novosItens = itens
            .Where(item => !nomesExistentes.Contains(item.Nome))
            .ToList();

        if (novosItens.Count == 0)
            return;

        await dbContext.Set<Item>().AddRangeAsync(novosItens);
        await dbContext.SaveChangesAsync();
    }
}
