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

    public IActionResult Listar()
    {
        List<Categoria> categorias = servicoCategoria.SelecionarTodos();

        return View(categorias);
    }
}