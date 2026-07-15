using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;

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
        throw new NotImplementedException();
    }

    public Curso? SelecionarPorId(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Curso> SelecionarTodos()
    {
        throw new NotImplementedException();
    }
}