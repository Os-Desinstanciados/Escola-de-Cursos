using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;

namespace EscolaDeCursos.Dominio.Modulos.ModuloTurma;

public class Turma : EntidadeBase<Turma>
{
    public string Nome { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public int NumeroMaximoAlunos { get; set; }
    //public Curso Curso { get; set }
    public Instrutor Instrutor { get; set; } = null!;
    public List<Aluno> Alunos { get; set; } = [];

    public Turma()
    {        
    }

    public Turma(
        string nome,
        DateTime dataInicio,
        DateTime dataTermino,
        int numeroMaximoAlunos,
        Instrutor instrutor,
        List<Aluno> alunos
    ) : this()
    {
        Nome = nome;
        DataInicio = dataInicio;
        DataTermino = dataTermino;
        NumeroMaximoAlunos = numeroMaximoAlunos;
        Instrutor = instrutor;
        Alunos = alunos;
    }
    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (DataInicio == default)
            erros.Add("O campo \"Data de Início\" deve ser preenchido.");

        if (DataTermino == default)
            erros.Add("O campo \"Data do Término\" deve ser preenchido.");

        if (DataTermino <= DataInicio)
            erros.Add("A data de término deve ser posterior à data de início.");

        if (NumeroMaximoAlunos <= 0)
            erros.Add("O campo \"Número Máximo de Alunos\" deve ser maior que zero.");

        if (Instrutor == null)
            erros.Add("O campo \"Instrutor\" deve ser preenchido.");

        return erros;
    }

    public override void Atualizar(Turma entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        DataInicio = entidadeAtualizada.DataInicio;
        DataTermino = entidadeAtualizada.DataTermino;
        NumeroMaximoAlunos = entidadeAtualizada.NumeroMaximoAlunos;
        Instrutor = entidadeAtualizada.Instrutor;
        Alunos = entidadeAtualizada.Alunos;        
    }

}