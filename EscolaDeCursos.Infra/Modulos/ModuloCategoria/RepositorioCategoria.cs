using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloCategoria;

public class RepositorioCategoria : IRepositorioCategoria
{
    private readonly EscolaDeCursosDbContext dbContext;

    public RepositorioCategoria(EscolaDeCursosDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Cadastrar(Categoria entidade)
    {
        dbContext.Categorias.Add(entidade);

        dbContext.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Categoria entidadeAtualizada)
    {
        Categoria? categoriaSelecionada = SelecionarPorId(idSelecionado);

        if (categoriaSelecionada is null)
            return false;

        categoriaSelecionada.Atualizar(entidadeAtualizada);

        dbContext.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Categoria? categoriaSelecionada = SelecionarPorId(idSelecionado);

        if (categoriaSelecionada is null)
            return false;

        dbContext.Categorias.Remove(categoriaSelecionada);

        dbContext.SaveChanges();

        return true;
    }

    public List<Categoria> Filtrar(Func<Categoria, bool> filtro)
    {
        throw new NotImplementedException();
    }

    public Categoria? SelecionarPorId(Guid idSelecionado)
    {
        return dbContext.Categorias.Find(idSelecionado);
    }

    public List<Categoria> SelecionarTodos()
    {
        return dbContext.Categorias.ToList();
    }
}