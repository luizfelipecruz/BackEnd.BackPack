using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infraestruture.Mappings;

internal class PersonagemMap : IEntityTypeConfiguration<Personagem>
{
    public void Configure(EntityTypeBuilder<Personagem> builder)
    {
        builder.Property(x => x.PesoMaximo).IsRequired().HasPrecision(18, 2);
        builder.Property(x => x.Nivel).IsRequired().HasDefaultValue(1);
        builder.Property(x => x.Experiencia).IsRequired().HasPrecision(18, 2).HasDefaultValue(0);
        builder.Property(x => x.IdUsuario).IsRequired();
        builder.HasMany(x => x.ItensInventario)
               .WithOne(x => x.Personagem)
               .HasForeignKey(x => x.IdPersonagem);

        builder.HasOne(x => x.Historia)
               .WithMany(x => x.Personagens)
               .HasForeignKey(x => x.IdHistoria);

        builder.HasOne(x => x.Local)
               .WithMany(x => x.Personagens)
               .HasForeignKey(x => x.IdLocal);
    }
}
