using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloCurso;

public class RepositorioCursoEmOrm : IRepositorioCurso
{
    private readonly EscolaDeCursosDbContext dbContext;

    public RepositorioCursoEmOrm(EscolaDeCursosDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Cadastrar(Curso entidade)
    {
        throw new NotImplementedException();
    }

    public bool Editar(Guid idSelecionado, Curso entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Curso> Filtrar(Func<Curso, bool> filtro)
    {
        return dbContext.Cursos
            .Include(c => c.Categoria)
            .Where(filtro)
            .ToList();
    }

    public Curso? SelecionarPorId(Guid idSelecionado)
    {
        return dbContext.Cursos
            .Include(c => c.Categoria)
            .FirstOrDefault(c => c.Id == idSelecionado);
    }

    public List<Curso> SelecionarTodos()
    {
        return dbContext.Cursos
            .Include(c => c.Categoria)
            .ToList();
    }
}