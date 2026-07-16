using EscolaDeCursos.Infra.Compartilhado.Orm.Config;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Compartilhado.Orm;

public sealed class EscolaDeCursosDbContext(
    DbContextOptions<EscolaDeCursosDbContext> options
    ) : DbContext(options)
{
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Instrutor> Instrutores => Set<Instrutor>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Curso> Cursos => Set<Curso>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        modelBuilder.ApplyConfiguration(new CursoConfiguration());
    }
}