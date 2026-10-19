using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infraestruture.Mappings;

internal class LocalMap : IEntityTypeConfiguration<Local>
{
    public void Configure(EntityTypeBuilder<Local> builder)
    {
        builder.Property(x => x.IdHistoria).IsRequired();
        builder.Property(x => x.Bioma).IsRequired();

        builder.HasOne(x => x.Historia)
               .WithMany(x => x.Locais)
               .HasForeignKey(x => x.IdHistoria)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Personagens)
               .WithOne(x => x.Local)
               .HasForeignKey(x => x.IdLocal)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
