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

    public Result Cadastrar(CadastrarCategoriaDto dto)
    {
        if (ExisteCategoriaComMesmoNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já existe uma categoria com este nome.");

        Categoria novaCategoria = new Categoria
        {
            Nome = dto.Nome
        };

        Result resultadoValidacao = ValidarEntidade(novaCategoria);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorio.Cadastrar(novaCategoria);

        return Result.Ok();
    }

    public Result Editar(EditarCategoriaDto dto)
    {
        if (ExisteCategoriaComMesmoNome(dto.Nome, dto.Id))
            return Falha(nameof(dto.Nome), "Já existe uma categoria com este nome.");

        Categoria categoriaAtualizada = new Categoria
        {
            Nome = dto.Nome
        };

        Result resultadoValidacao = ValidarEntidade(categoriaAtualizada);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorio.Editar(dto.Id, categoriaAtualizada);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Categoria não encontrada.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Categoria? categoria = repositorio.SelecionarPorId(id);

        if (categoria == null)
            return Falha(string.Empty, "Categoria não encontrada.");

        repositorio.Excluir(id);

        return Result.Ok();
    }

    private bool ExisteCategoriaComMesmoNome(string nome, Guid? idIgnorado = null)
    {
        string nomeNormalizado = nome.Trim().ToLowerInvariant();

        return repositorio
            .SelecionarTodos()
            .Any(c =>
                c.Id != idIgnorado &&
                c.Nome.Trim().ToLowerInvariant() == nomeNormalizado
            );
    }

    public List<ListarCategoriasDto> SelecionarTodos()
    {
        return repositorio
            .SelecionarTodos()
            .Select(c => new ListarCategoriasDto(
                c.Id,
                c.Nome
            ))
            .ToList();
    }

    public Result<DetalhesCategoriaDto> SelecionarPorId(Guid id)
    {
        Categoria? categoria = repositorio.SelecionarPorId(id);

        if (categoria == null)
            return Result.Fail("Categoria não encontrada.");

        return Result.Ok(new DetalhesCategoriaDto(
            categoria.Id,
            categoria.Nome
        ));
    }
}