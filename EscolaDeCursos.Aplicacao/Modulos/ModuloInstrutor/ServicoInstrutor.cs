using FluentResults;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;

public class ServicoInstrutor : ServicoBase<Instrutor>
{
    private readonly IRepositorioInstrutor repositorioInstrutor;   

    public ServicoInstrutor(
        IRepositorioInstrutor repositorioInstrutor       
    )
    {
        this.repositorioInstrutor = repositorioInstrutor;       
    }

    public Result Cadastrar(CadastrarInstrutorDto dto)
    {
        if (ExisteInstrutorComMesmoTelefone(dto.Telefone))
            return Falha(nameof(dto.Telefone), "Já existe um instrutor com este telefone.");

        if (ExisteInstrutorComMesmoEmail(dto.Email))
            return Falha(nameof(dto.Email), "Já existe um instrutor com este email.");

        Instrutor novoInstrutor = new Instrutor(
            dto.Nome,
            dto.Endereco,
            dto.Telefone,
            dto.Email            
        );

        Result resultadoValidacao = ValidarEntidade(novoInstrutor);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioInstrutor.Cadastrar(novoInstrutor);

        return Result.Ok();
    }

    public Result Editar(EditarInstrutorDto dto)
    {
        if (ExisteInstrutorComMesmoTelefone(dto.Telefone, dto.Id))
            return Falha(nameof(dto.Telefone), "Já existe um instrutor com este telefone.");

        if (ExisteInstrutorComMesmoEmail(dto.Email, dto.Id))
            return Falha(nameof(dto.Email), "Já existe um instrutor com este email.");

        Instrutor instrutorAtualizado = new Instrutor(
            dto.Nome,
            dto.Endereco,
            dto.Telefone,
            dto.Email
        );

        Result resultadoValidacao = ValidarEntidade(instrutorAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioInstrutor.Editar(dto.Id, instrutorAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Instrutor não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Instrutor? instrutor = repositorioInstrutor.SelecionarPorId(id);

        if (instrutor == null)
            return Falha(string.Empty, "Instrutor não encontrado.");        

        repositorioInstrutor.Excluir(id);

        return Result.Ok();
    }

    public List<ListarInstrutoresDto> SelecionarTodos()
    {
        return repositorioInstrutor
            .SelecionarTodos()
            .Select(a => new ListarInstrutoresDto(a.Id, a.Nome, a.Endereco, a.Telefone, a.Email))
            .ToList();
    }

    public Result<DetalhesInstrutorDto> SelecionarPorId(Guid id)
    {
        Instrutor? instrutor = repositorioInstrutor.SelecionarPorId(id);

        if (instrutor == null)
            return Result.Fail("Instrutor não encontrado.");

        return Result.Ok(new DetalhesInstrutorDto(
            instrutor.Id,
            instrutor.Nome,
            instrutor.Endereco,
            instrutor.Telefone,
            instrutor.Email
        ));
    }

    private bool ExisteInstrutorComMesmoEmail(string email, Guid? idIgnorado = null)
    {
        string emailNormalizado = NormalizarEmail(email);

        return repositorioInstrutor
            .SelecionarTodos()
            .Any(i =>
                i.Id != idIgnorado &&
                NormalizarEmail(i.Email) == emailNormalizado
            );
    }

    private bool ExisteInstrutorComMesmoTelefone(string telefone, Guid? idIgnorado = null)
    {
        string telefoneNormalizado = NormalizarTelefone(telefone);

        return repositorioInstrutor
            .SelecionarTodos()
            .Any(i =>
                i.Id != idIgnorado &&
                NormalizarTelefone(i.Telefone) == telefoneNormalizado
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