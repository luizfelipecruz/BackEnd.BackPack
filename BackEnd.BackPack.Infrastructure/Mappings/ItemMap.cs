using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infrastructure.Mappings;

internal class ItemMap : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(x => x.Peso).IsRequired();
        builder.Property(x => x.Tipo).IsRequired();
        builder.Property(x => x.Raridade).IsRequired();
        builder.Property(x => x.Dureza).IsRequired();
        builder.Property(x => x.Durabilidade).IsRequired();
        builder.Property(x => x.Tamanho).IsRequired();

        builder.HasMany(x => x.Inventarios)
               .WithOne(x => x.Item)
               .HasForeignKey(x => x.IdItem)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Historia)
               .WithMany(x => x.Itens)
               .HasForeignKey(x => x.IdHistoria)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
