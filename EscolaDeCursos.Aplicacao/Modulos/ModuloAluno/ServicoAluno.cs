using FluentResults;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public class ServicoAluno : ServicoBase<Aluno>
{
    private readonly IRepositorioAluno repositorioAluno;   

    public ServicoAluno(
        IRepositorioAluno repositorioAluno       
    )
    {
        this.repositorioAluno = repositorioAluno;       
    }

    public Result Cadastrar(CadastrarAlunoDto dto)
    {
        if (ExisteAlunoComMesmoTelefone(dto.Telefone))
            return Falha(nameof(dto.Telefone), "Já existe um aluno com este telefone.");

        if (ExisteAlunoComMesmoEmail(dto.Email))
            return Falha(nameof(dto.Email), "Já existe um aluno com este email.");

        Aluno novoAluno = new Aluno(
            dto.Nome,
            dto.Endereco,
            dto.Telefone,
            dto.Email            
        );

        Result resultadoValidacao = ValidarEntidade(novoAluno);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioAluno.Cadastrar(novoAluno);

        return Result.Ok();
    }

    public Result Editar(EditarAlunoDto dto)
    {
        if (ExisteAlunoComMesmoTelefone(dto.Telefone, dto.Id))
            return Falha(nameof(dto.Telefone), "Já existe um aluno com este telefone.");

        if (ExisteAlunoComMesmoEmail(dto.Email, dto.Id))
            return Falha(nameof(dto.Email), "Já existe um aluno com este email.");

        Aluno alunoAtualizado = new Aluno(
            dto.Nome,
            dto.Endereco,
            dto.Telefone,
            dto.Email
        );

        Result resultadoValidacao = ValidarEntidade(alunoAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioAluno.Editar(dto.Id, alunoAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Aluno não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Aluno? aluno = repositorioAluno.SelecionarPorId(id);

        if (aluno == null)
            return Falha(string.Empty, "Aluno não encontrado.");        

        repositorioAluno.Excluir(id);

        return Result.Ok();
    }

    public List<ListarAlunosDto> SelecionarTodos()
    {
        return repositorioAluno
            .SelecionarTodos()
            .Select(a => new ListarAlunosDto(a.Id, a.Nome, a.Endereco, a.Telefone, a.Email))
            .ToList();
    }

    public Result<DetalhesAlunoDto> SelecionarPorId(Guid id)
    {
        Aluno? aluno = repositorioAluno.SelecionarPorId(id);

        if (aluno == null)
            return Result.Fail("Aluno não encontrado.");

        return Result.Ok(new DetalhesAlunoDto(
            aluno.Id,
            aluno.Nome,
            aluno.Endereco,
            aluno.Telefone,
            aluno.Email
        ));
    }

    private bool ExisteAlunoComMesmoEmail(string email, Guid? idIgnorado = null)
    {
        string emailNormalizado = NormalizarEmail(email);

        return repositorioAluno
            .SelecionarTodos()
            .Any(a =>
                a.Id != idIgnorado &&
                NormalizarEmail(a.Email) == emailNormalizado
            );
    }

    private bool ExisteAlunoComMesmoTelefone(string telefone, Guid? idIgnorado = null)
    {
        string telefoneNormalizado = NormalizarTelefone(telefone);

        return repositorioAluno
            .SelecionarTodos()
            .Any(a =>
                a.Id != idIgnorado &&
                NormalizarTelefone(a.Telefone) == telefoneNormalizado
            );
    }    

    private static string NormalizarEmail(string email)
    {
        return email.Trim().ToLowerInvariant();
    }

    private static string NormalizarTelefone(string telefone)
    {
        return new string(telefone.Where(char.IsDigit).ToArray());
    }
}