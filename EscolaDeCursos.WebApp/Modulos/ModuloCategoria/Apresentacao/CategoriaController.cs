using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.WebApp.Modulos.ModuloCategoria.Apresentacao.ViewModels;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria.Apresentacao;

public class CategoriaController : Controller
{
    private readonly ServicoCategoria servicoCategoria;
    private readonly IMapper mapper;

    public CategoriaController(
        ServicoCategoria servicoCategoria,
        IMapper mapper
    )
    {
        this.servicoCategoria = servicoCategoria;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastrarCategoriaViewModel cadastrarVM)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVM);

        Categoria categoria = mapper.Map<Categoria>(cadastrarVM);

        Result resultado = servicoCategoria.Cadastrar(categoria);

        if (resultado.IsFailed)
            return View(cadastrarVM);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        Categoria? categoria = servicoCategoria.SelecionarPorId(id);

        if (categoria is null)
            return NotFound();

        EditarCategoriaViewModel editarVM =
            mapper.Map<EditarCategoriaViewModel>(categoria);

        return View(editarVM);
    }

    [HttpPost]
    public IActionResult Editar(EditarCategoriaViewModel editarVM)
    {
        if (!ModelState.IsValid)
            return View(editarVM);

        Categoria categoria = mapper.Map<Categoria>(editarVM);

        Result resultado = servicoCategoria.Editar(
            editarVM.Id,
            categoria
        );

        if (resultado.IsFailed)
            return View(editarVM);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Listar()
    {
        List<Categoria> categorias = servicoCategoria.SelecionarTodos();

        return View(categorias);
    }
}