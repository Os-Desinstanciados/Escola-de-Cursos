using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloInstrutor;

public sealed class RepositorioInstrutorEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Instrutor>(dbContext), IRepositorioInstrutor
{
    public override List<Instrutor> SelecionarTodos()
    {
        return registros.OrderBy(i => i.Nome).ToList();
    }

    public override List<Instrutor> Filtrar(Func<Instrutor, bool> filtro)
    {
        return registros.Where(filtro).OrderBy(i => i.Nome).ToList();
    }
}