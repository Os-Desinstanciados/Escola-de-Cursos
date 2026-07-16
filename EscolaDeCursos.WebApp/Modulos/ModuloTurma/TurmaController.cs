using AutoMapper;
using FluentResults;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaController(ServicoTurma servicoTurma, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarTurmasDto> dtos = servicoTurma.SelecionarTodos();

        List<ListarTurmasViewModel> listarVms = mapeador.Map<List<ListarTurmasViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarTurmaViewModel cadastrarVm = new CadastrarTurmaViewModel(
            string.Empty,
            DateTime.Today,
            DateTime.Today,            
            0,
            Guid.Empty,            
            SelecionarInstrutores()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarTurmaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm with { Instrutores = SelecionarInstrutores() });

        CadastrarTurmaDto dto = mapeador.Map<CadastrarTurmaDto>(cadastrarVm);

        Result resultado = servicoTurma.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm with { Instrutores = SelecionarInstrutores() });
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesTurmaDto> resultado = servicoTurma.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        EditarTurmaViewModel editarVm =
            mapeador.Map<EditarTurmaViewModel>(resultado.Value) with { Instrutores = SelecionarInstrutores() };

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarTurmaViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm with { Instrutores = SelecionarInstrutores() });

        EditarTurmaDto dto = mapeador.Map<EditarTurmaDto>(editarVm);

        Result resultado = servicoTurma.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(editarVm with { Instrutores = SelecionarInstrutores() });
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesTurmaDto> resultado = servicoTurma.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirTurmaViewModel excluirVm = mapeador.Map<ExcluirTurmaViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirTurmaViewModel excluirVm)
    {
        Result resultado = servicoTurma.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    private List<OpcaoInstrutorViewModel> SelecionarInstrutores()
    {
        List<OpcaoInstrutorDto> dtos = servicoTurma.SelecionarInstrutores();

        return mapeador.Map<List<OpcaoInstrutorViewModel>>(dtos);
    }
}

