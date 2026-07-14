using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.ModuloCategoria;

public class Categoria : EntidadeBase<Categoria>
{
    public string Nome { get; set; } = string.Empty;
    public Categoria()
    {
    }

    public override void Atualizar(Categoria entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo nome deve ser preenchido.");

        if (Nome.Length < 3 || Nome.Length > 35)
            erros.Add("O campo nome deve conter no entre 3 e 35 caracteres.");

        return erros;
    }
}