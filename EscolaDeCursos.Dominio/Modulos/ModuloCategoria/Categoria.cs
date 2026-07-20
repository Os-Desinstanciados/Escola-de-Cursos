using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

public class Categoria : EntidadeBase<Categoria>
{
    public string Nome { get; set; } = string.Empty;
    public Categoria()
    {
    }

    public override void Atualizar(Categoria entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
        {
            erros.Add("O campo nome deve ser preenchido.");

            return erros;
        }

        if (Nome.Length < 3 || Nome.Length > 35)
            erros.Add("O campo nome deve conter entre 3 e 35 caracteres.");

        return erros;
    }
}