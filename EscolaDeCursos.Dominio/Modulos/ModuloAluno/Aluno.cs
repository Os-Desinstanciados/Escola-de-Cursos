using System.Text.RegularExpressions;
using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAluno;

public class Aluno : EntidadeBase<Aluno>
{
    public string Nome { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;    
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    public Aluno()
    {
    }

    public Aluno(
        string nome,
        string endereco,
        string telefone,
        string email
    ) : this()
    {
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
        Email = email;        
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");        

        if (string.IsNullOrWhiteSpace(Endereco) || Endereco.Length < 2 || Endereco.Length > 100)
            erros.Add("O campo \"Endereço\" deve conter entre 2 e 100 caracteres.");        

        if (!Regex.IsMatch(Telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$"))
            erros.Add("O campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.");

        if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            erros.Add("O campo \"E-mail\" deve conter um endereço de e-mail válido.");
        

        return erros;
    }

    public override void Atualizar(Aluno entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Endereco = entidadeAtualizada.Endereco;
        Email = entidadeAtualizada.Email;
        Telefone = entidadeAtualizada.Telefone;        
    }
}