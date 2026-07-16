using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoProfile : Profile
{
    public CursoProfile()
    {
        CreateMap<ListarCursosDto, ListarCursoViewModel>();
        CreateMap<CadastrarCursoViewModel, CadastrarCursoDto>();
        CreateMap<DetalhesCursoDto, EditarCursoViewModel>();
        CreateMap<EditarCursoViewModel, EditarCursoDto>();
        CreateMap<DetalhesCursoDto, ExcluirCursoViewModel>();
    }
}