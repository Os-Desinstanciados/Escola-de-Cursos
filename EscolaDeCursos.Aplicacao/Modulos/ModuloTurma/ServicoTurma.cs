using FluentResults;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

public class ServicoTurma : ServicoBase<Turma>
{
    private readonly IRepositorioTurma repositorioTurma;   
    private readonly IRepositorioInstrutor repositorioInstrutor;  
       

    public ServicoTurma(
        IRepositorioTurma repositorioTurma,
        IRepositorioInstrutor repositorioInstrutor               
    )
    {
        this.repositorioTurma = repositorioTurma;
        this.repositorioInstrutor = repositorioInstrutor;               
    }

    public Result Cadastrar(CadastrarTurmaDto dto)
    { 
        Result<Instrutor> resultadoInstrutor = SelecionarInstrutorRequired(dto.InstrutorId);

        if (resultadoInstrutor.IsFailed)
            return resultadoInstrutor.ToResult();

        Turma novaTurma = new Turma(
            dto.Nome,
            dto.DataInicio,
            dto.DataTermino,
            dto.NumeroMaximoAlunos,
            resultadoInstrutor.Value            
        );

        Result resultadoValidacao = ValidarEntidade(novaTurma);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioTurma.Cadastrar(novaTurma);

        return Result.Ok();
    }

    public Result Editar(EditarTurmaDto dto)
    {       
        Result<Instrutor> resultadoInstrutor = SelecionarInstrutorRequired(dto.InstrutorId);

        if (resultadoInstrutor.IsFailed)
            return resultadoInstrutor.ToResult();

        Turma turmaAtualizada = new Turma(
            dto.Nome,
            dto.DataInicio,
            dto.DataTermino,
            dto.NumeroMaximoAlunos,
            resultadoInstrutor.Value
        );

        Result resultadoValidacao = ValidarEntidade(turmaAtualizada);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioTurma.Editar(dto.Id, turmaAtualizada);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Turma não encontrada.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Turma? turma = repositorioTurma.SelecionarPorId(id);

        if (turma == null)
            return Falha(string.Empty, "Turma não encontrada.");        

        repositorioTurma.Excluir(id);

        return Result.Ok();
    }

    public List<ListarTurmasDto> SelecionarTodos()
    {
        return repositorioTurma
            .SelecionarTodos()
            .Select(t => new ListarTurmasDto(
                t.Id,
                t.Nome,
                t.DataInicio,
                t.DataTermino,
                t.NumeroMaximoAlunos,
                t.Instrutor.Id,
                t.Instrutor.Nome                
            ))
            .ToList();
    }

    public Result<DetalhesTurmaDto> SelecionarPorId(Guid id)
    {
        Turma? turma = repositorioTurma.SelecionarPorId(id);

        if (turma == null)
            return Result.Fail("Turma não encontrada.");

        return Result.Ok(new DetalhesTurmaDto(
            turma.Id,
            turma.Nome,
            turma.DataInicio,
            turma.DataTermino,
            turma.NumeroMaximoAlunos,
            turma.Instrutor.Id,
            turma.Instrutor.Nome            
        ));
    } 
    
    public List<OpcaoInstrutorDto> SelecionarInstrutores()
    {
        return repositorioInstrutor
            .SelecionarTodos()
            .Select(c => new OpcaoInstrutorDto(c.Id, c.Nome))
            .ToList();
    }

    private Result<Instrutor> SelecionarInstrutorRequired(Guid? instrutorId)
    {
        if (instrutorId == null || instrutorId == Guid.Empty)
            return Result.Fail<Instrutor>(new Error("Selecione um contato válido.").WithMetadata("Campo", nameof(CadastrarTurmaDto.InstrutorId)));

        Instrutor? instrutor = repositorioInstrutor.SelecionarPorId(instrutorId.Value);
      

        return Result.Ok<Instrutor>(instrutor);
    }
       
}