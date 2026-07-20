using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

namespace EscolaDeCursos.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {          
        services.AddScoped<ServicoAluno>();
        services.AddScoped<ServicoInstrutor>();        
        services.AddScoped<ServicoCategoria>();
        services.AddScoped<ServicoCurso>();
        services.AddScoped<ServicoAula>();
        services.AddScoped<ServicoTurma>();
        services.AddScoped<ServicoMatricula>();
    }
}
