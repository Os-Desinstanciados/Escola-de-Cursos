using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Apresentacao.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso.Apresentacao;

public class CursoController(ServicoCurso servicoCurso,IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarCursosDto> dtos = servicoCurso.SelecionarTodos();

        List<ListarCursoViewModel> listarVms =
            mapeador.Map<List<ListarCursoViewModel>>(dtos);

        return View(listarVms);
    }
}