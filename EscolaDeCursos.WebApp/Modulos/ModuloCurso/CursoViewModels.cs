using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public record ListarCursoViewModel(
    Guid Id,
    string Nome,
    string Categoria,
    NivelCurso Nivel,
    int CargaHoraria
);

public record CadastrarCursoViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Categoria\" deve ser preenchido.")]
    Guid CategoriaId,

    [Required(ErrorMessage = "O campo \"Nivel\" deve ser preenchido.")]
    NivelCurso Nivel,

    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    int CargaHoraria
);

public record EditarCursoViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Categoria\" deve ser preenchido.")]
    Guid CategoriaId,

    [Required(ErrorMessage = "O campo \"Nivel\" deve ser preenchido.")]
    NivelCurso Nivel,

    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    int CargaHoraria
);

public record ExcluirCursoViewModel(
    Guid Id,
    string Nome,
    string Categoria,
    NivelCurso Nivel,
    int CargaHoraria
);