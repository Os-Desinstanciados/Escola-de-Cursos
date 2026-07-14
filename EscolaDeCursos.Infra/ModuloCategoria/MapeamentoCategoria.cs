using EscolaDeCursos.Dominio.ModuloCategoria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.ModuloCategoria;

public class MapeamentoCategoria : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("TBCategoria");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(35)
            .IsRequired();
    }
}