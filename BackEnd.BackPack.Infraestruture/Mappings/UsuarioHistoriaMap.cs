using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infraestruture.Mappings;

internal class UsuarioHistoriaMap : IEntityTypeConfiguration<UsuarioHistoria>
{
    public void Configure(EntityTypeBuilder<UsuarioHistoria> builder)
    {
        builder.HasOne(x => x.Usuario)
               .WithMany(x => x.Historias)
               .HasForeignKey(x => x.IdUsuario);

        builder.HasOne(x => x.Historia)
               .WithMany(x => x.Usuarios)
               .HasForeignKey(x => x.IdHistoria);
    }
}
