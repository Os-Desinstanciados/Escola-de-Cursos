using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Apresentacao.ViewModels;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso.Apresentacao;

public class CursoController(
    ServicoCurso servicoCurso,
    ServicoCategoria servicoCategoria,
    IMapper mapeador
) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarCursosDto> dtos = servicoCurso.SelecionarTodos();

        List<ListarCursoViewModel> listarVms = mapeador.Map<List<ListarCursoViewModel>>(dtos);

        return View(listarVms);
    }
    
    [HttpGet]
    public ActionResult Cadastrar()
    {
        List<ListarCategoriasDto> categorias = servicoCategoria.SelecionarTodos();

        ViewBag.Categorias = new SelectList(
            categorias,
            nameof(ListarCategoriasDto.Id),
            nameof(ListarCategoriasDto.Nome)
        );

        CadastrarCursoViewModel cadastrarVm = new(
            string.Empty,
            Guid.Empty,
            NivelCurso.NaoDefinido,
            0
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarCursoViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarCursoDto dto = mapeador.Map<CadastrarCursoDto>(cadastrarVm);

        Result resultado = servicoCurso.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }
    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesCursoDto> resultado = servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        List<ListarCategoriasDto> categorias = servicoCategoria.SelecionarTodos();

        ViewBag.Categorias = new SelectList(
            categorias,
            nameof(ListarCategoriasDto.Id),
            nameof(ListarCategoriasDto.Nome)
        );

        EditarCursoViewModel editarVm = mapeador.Map<EditarCursoViewModel>(resultado.Value);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarCursoViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategorias();

            return View(editarVm);
        }

        EditarCursoDto dto = mapeador.Map<EditarCursoDto>(editarVm);

        Result resultado = servicoCurso.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            CarregarCategorias();

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }
    private void CarregarCategorias()
    {
        List<ListarCategoriasDto> categorias = servicoCategoria.SelecionarTodos();

        ViewBag.Categorias = new SelectList(
            categorias,
            nameof(ListarCategoriasDto.Id),
            nameof(ListarCategoriasDto.Nome)
        );
    }
}