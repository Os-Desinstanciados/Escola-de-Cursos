using EscolaDeCursos.Aplicacao.ModuloCategoria;
using EscolaDeCursos.Dominio.ModuloCategoria;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria.Apresentacao;

public class CategoriaController : Controller
{
    private readonly ServicoCategoria servicoCategoria;

    public CategoriaController(ServicoCategoria servicoCategoria)
    {
        this.servicoCategoria = servicoCategoria;
    }

    public IActionResult Listar()
    {
        List<Categoria> categorias = servicoCategoria.SelecionarTodos();

        return View(categorias);
    }
}