using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public class ServicoCurso : ServicoBase<Curso>
{
    private readonly IRepositorioCurso repositorioCurso;
    public ServicoCurso(
        IRepositorioCurso repositorioCurso
    )
    {
        this.repositorioCurso = repositorioCurso;
    }
}