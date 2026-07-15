using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public record ListarCursosDto(
    Guid Id,
    string Nome,
    string Categoria,
    NivelCurso Nivel,
    int CargaHoraria
);

public record CadastrarCursoDto(
    string Nome,
    Guid CategoriaId,
    NivelCurso Nivel,
    int CargaHoraria
);

public record DetalhesCursoDto(
    Guid Id,
    string Nome,
    Guid CategoriaId,
    string Categoria,
    NivelCurso Nivel,
    int CargaHoraria
);