using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Apresentacao.ViewModels;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso.Apresentacao;

public class CursoProfile : Profile
{
    public CursoProfile()
    {
        CreateMap<ListarCursosDto, ListarCursoViewModel>();
        CreateMap<CadastrarCursoViewModel, CadastrarCursoDto>();
    }
}