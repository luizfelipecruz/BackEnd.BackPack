using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infraestruture.Mappings;

internal class InventarioMap : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {

        builder.Property(x => x.Quantidade).IsRequired();
        builder.Property(x => x.Equipado).IsRequired().HasDefaultValue(false);
        builder.Property(x => x.DurabilidadeAtual).IsRequired().HasDefaultValue(100);
        builder.ToTable(t => t.HasCheckConstraint(
        "CK_Inventario_DurabilidadeAtual",
        "[DurabilidadeAtual] >= 0 AND [DurabilidadeAtual] <= 100"));

        builder.HasOne(x => x.Personagem)
               .WithMany(x => x.ItensInventario)
               .HasForeignKey(x => x.IdPersonagem)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Item)
               .WithMany(x => x.Inventarios)
               .HasForeignKey(x => x.IdItem)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
