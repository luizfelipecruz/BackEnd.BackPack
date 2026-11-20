using BackEnd.BackPack.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.BackPack.Infrastructure.Mappings;

internal class UsuarioHistoriaMap : IEntityTypeConfiguration<UsuarioHistoria>
{
    public void Configure(EntityTypeBuilder<UsuarioHistoria> builder)
    {
        builder.HasOne(x => x.Usuario)
               .WithMany(x => x.Historias)
               .HasForeignKey(x => x.IdUsuario)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Historia)
               .WithMany(x => x.Usuarios)
               .HasForeignKey(x => x.IdHistoria)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
