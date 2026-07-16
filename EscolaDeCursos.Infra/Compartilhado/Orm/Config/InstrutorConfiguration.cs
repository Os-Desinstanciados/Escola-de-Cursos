using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAgenda.WebApp.Compartilhado.Infra.Orm.Config;

public sealed class InstrutorConfiguration : IEntityTypeConfiguration<Instrutor>
{
    public void Configure(EntityTypeBuilder<Instrutor> builder)
    {
        builder.ToTable("TBInstrutor");

        builder.HasKey(a => a.Id)
            .HasName("PK_TBInstrutor");

        builder.Property(a => a.Id)
            .ValueGeneratedNever();

        builder.Property(a => a.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Endereco)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Telefone)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(a => a.Email)
            .HasMaxLength(255)
            .IsRequired();        

        // Índice de exclusividade
        builder.HasIndex(a => a.Telefone)
            .IsUnique()
            .HasDatabaseName("UQ_TBInstrutor_Telefone");
            
        builder.HasIndex(a => a.Email)
            .IsUnique()
            .HasDatabaseName("UQ_TBInstrutor_Email");

    }
}