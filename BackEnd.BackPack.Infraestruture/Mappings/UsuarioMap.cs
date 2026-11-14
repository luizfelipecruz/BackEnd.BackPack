using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infraestruture.Mappings;

internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.Property(x => x.Admin).IsRequired()
                                      .HasDefaultValue(false);

        builder.HasMany(x => x.Personagems)
               .WithOne(x => x.Usuario)
               .HasForeignKey(x => x.IdUsuario)
               .OnDelete(DeleteBehavior.NoAction);
    }
}