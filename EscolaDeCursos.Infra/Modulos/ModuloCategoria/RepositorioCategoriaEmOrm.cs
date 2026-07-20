using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloCategoria;

public sealed class RepositorioCategoriaEmOrm(
    EscolaDeCursosDbContext dbContext
) : RepositorioBaseEmOrm<Categoria>(dbContext), IRepositorioCategoria
{
    public override List<Categoria> SelecionarTodos()
    {
        return registros
            .OrderBy(c => c.Nome)
            .ToList();
    }

    public override List<Categoria> Filtrar(Func<Categoria, bool> filtro)
    {
        return registros
            .Where(filtro)
            .OrderBy(c => c.Nome)
            .ToList();
    }
}