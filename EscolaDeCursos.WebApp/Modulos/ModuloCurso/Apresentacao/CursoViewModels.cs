using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso.Apresentacao.ViewModels;

public record ListarCursoViewModel(
    Guid Id,
    string Nome,
    string Categoria,
    NivelCurso Nivel,
    int CargaHoraria
);