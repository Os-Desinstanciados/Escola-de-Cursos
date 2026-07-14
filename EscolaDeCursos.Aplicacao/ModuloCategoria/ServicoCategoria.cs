using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.ModuloCategoria;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.ModuloCategoria;

public class ServicoCategoria : ServicoBase<Categoria>
{
    private readonly IRepositorioCategoria repositorio;

    public ServicoCategoria(IRepositorioCategoria repositorio)
    {
        this.repositorio = repositorio;
    }



}