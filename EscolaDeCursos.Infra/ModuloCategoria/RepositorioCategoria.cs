using EscolaDeCursos.Dominio.ModuloCategoria;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.ModuloCategoria;

public class RepositorioCategoria : IRepositorioCategoria
{
    private readonly EscolaDeCursosDbContext dbContext;

    public RepositorioCategoria(EscolaDeCursosDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Cadastrar(Categoria entidade)
    {
        throw new NotImplementedException();
    }

    public bool Editar(Guid idSelecionado, Categoria entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Categoria> Filtrar(Func<Categoria, bool> filtro)
    {
        throw new NotImplementedException();
    }

    public Categoria? SelecionarPorId(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Categoria> SelecionarTodos()
    {
        return dbContext.Categorias.ToList();
    }
}