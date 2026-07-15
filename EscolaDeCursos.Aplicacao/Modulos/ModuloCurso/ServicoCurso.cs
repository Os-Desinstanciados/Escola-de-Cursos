using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public class ServicoCurso : ServicoBase<Curso>
{
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCurso(
        IRepositorioCurso repositorioCurso,
        IRepositorioCategoria repositorioCategoria
    )
    {
        this.repositorioCurso = repositorioCurso;
        this.repositorioCategoria = repositorioCategoria;
    }

    public Result Cadastrar(CadastrarCursoDto dto)
    {
        if (ExisteCursoComMesmoNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já existe um curso com este nome.");

        if (!ExisteCategoria(dto.CategoriaId))
            return Falha(nameof(dto.CategoriaId), "A categoria selecionada não existe.");

        Curso novoCurso = new Curso
        {
            Nome = dto.Nome,
            CategoriaId = dto.CategoriaId,
            Nivel = dto.Nivel,
            CargaHoraria = dto.CargaHoraria
        };

        Result resultadoValidacao = ValidarEntidade(novoCurso);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCurso.Cadastrar(novoCurso);

        return Result.Ok();
    }

    public List<ListarCursosDto> SelecionarTodos()
    {
        return repositorioCurso
            .SelecionarTodos()
            .Select(c => new ListarCursosDto(
                c.Id,
                c.Nome,
                c.Categoria?.Nome ?? string.Empty,
                c.Nivel,
                c.CargaHoraria
            ))
            .ToList();
    }

    public Result<DetalhesCursoDto> SelecionarPorId(Guid id)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(id);

        if (curso is null)
            return Result.Fail("Curso não encontrado.");

        return Result.Ok(new DetalhesCursoDto(
            curso.Id,
            curso.Nome,
            curso.CategoriaId,
            curso.Categoria?.Nome ?? string.Empty,
            curso.Nivel,
            curso.CargaHoraria
        ));
    }

    private bool ExisteCursoComMesmoNome(string nome, Guid? idIgnorado = null)
    {
        string nomeNormalizado = nome.Trim().ToLowerInvariant();

        return repositorioCurso
            .SelecionarTodos()
            .Any(c =>
                c.Id != idIgnorado &&
                c.Nome.Trim().ToLowerInvariant() == nomeNormalizado
            );
    }

    private bool ExisteCategoria(Guid categoriaId)
    {
        return repositorioCategoria.SelecionarPorId(categoriaId) is not null;
    }
}