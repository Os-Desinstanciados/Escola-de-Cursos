using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

public class ServicoCategoria : ServicoBase<Categoria>
{
    private readonly IRepositorioCategoria repositorio;

    public ServicoCategoria(IRepositorioCategoria repositorio)
    {
        this.repositorio = repositorio;
    }

    public Result Cadastrar(Categoria categoria)
    {
        Result resultadoValidacao = ValidarEntidade(categoria);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorio.Cadastrar(categoria);

        return Result.Ok();
    }



    public List<Categoria> SelecionarTodos()
    {
        return repositorio.SelecionarTodos();
    }

}