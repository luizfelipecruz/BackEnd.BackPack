using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infraestruture.Mappings;

internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Login).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Tipo).IsRequired();

        builder.HasMany(x => x.Personagems)
               .WithOne(x => x.Usuario)
               .HasForeignKey(x => x.IdUsuario);
    }
}
