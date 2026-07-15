using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaProfile : Profile
{
    public TurmaProfile()
    {
        CreateMap<OpcaoInstrutorDto, OpcaoInstrutorViewModel>();
        CreateMap<ListarTurmasDto, ListarTurmasViewModel>();
        CreateMap<CadastrarTurmaViewModel, CadastrarTurmaDto>();
        CreateMap<EditarTurmaViewModel, EditarTurmaDto>();

        CreateMap<DetalhesTurmaDto, EditarTurmaViewModel>()
            .ForCtorParam("Instrutores", opt => opt.MapFrom(_ => new List<OpcaoInstrutorViewModel>()));

        CreateMap<DetalhesTurmaDto, ExcluirTurmaViewModel>();
    }
}