using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso.Apresentacao;

public class CursoController(
    ServicoCurso servicoCurso,
    IMapper mapeador
) : Controller
{

}