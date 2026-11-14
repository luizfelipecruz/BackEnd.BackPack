using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infraestruture.Mappings;

internal class HistoriaMap : IEntityTypeConfiguration<Historia>
{
    public void Configure(EntityTypeBuilder<Historia> builder)
    {
        builder.Property(x => x.StatusHistoria).IsRequired();

        builder.HasMany(x => x.Usuarios)
               .WithOne(x => x.Historia)
               .HasForeignKey(x => x.IdHistoria)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Personagens)
               .WithOne(x => x.Historia)
               .HasForeignKey(x => x.IdHistoria)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
