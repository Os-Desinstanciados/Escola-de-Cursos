using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloTurma;

public sealed class RepositorioTurmaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Turma>(dbContext), IRepositorioTurma
{
    public override List<Turma> SelecionarTodos()
    {
        return registros.OrderBy(i => i.Nome).ToList();
    }

    public override List<Turma> Filtrar(Func<Turma, bool> filtro)
    {
        return registros.Where(filtro).OrderBy(i => i.Nome).ToList();
    }
}