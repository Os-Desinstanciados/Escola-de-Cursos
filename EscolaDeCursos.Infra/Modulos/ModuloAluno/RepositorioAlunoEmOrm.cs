using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloAluno;

public sealed class RepositorioAlunoEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Aluno>(dbContext), IRepositorioAluno
{
    public override List<Aluno> SelecionarTodos()
    {
        return registros.OrderBy(a => a.Nome).ToList();
    }

    public override List<Aluno> Filtrar(Func<Aluno, bool> filtro)
    {
        return registros.Where(filtro).OrderBy(a => a.Nome).ToList();
    }
}