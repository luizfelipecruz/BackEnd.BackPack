using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infrastructure.Mappings;

public abstract class EntidadeCompletaMap<T> : EntidadeBaseMap<T>
    where T : EntidadeCompleta
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.Descricao)
               .HasMaxLength(200);
    }
}