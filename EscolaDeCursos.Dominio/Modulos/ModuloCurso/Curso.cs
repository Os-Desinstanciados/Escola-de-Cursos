using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCurso;

public class Curso : EntidadeBase<Curso>
{
    public string Nome { get; set; } = string.Empty;
    public NivelCurso Nivel { get; set; }
    public int CargaHoraria { get; set; }
    public Categoria? Categoria { get; set; } = null!;
    public List<Aula> Aulas { get; set; } = [];
    public Curso()
    {
    }

    public Curso(
        string nome,
        NivelCurso nivel,
        int cargaHoraria,
        Categoria categoria
    ) : this()
    {
        Nome = nome;
        Nivel = nivel;
        CargaHoraria = cargaHoraria;
        Categoria = categoria;
    }

    public override void Atualizar(Curso entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Nivel = entidadeAtualizada.Nivel;
        CargaHoraria = entidadeAtualizada.CargaHoraria;
        Categoria = entidadeAtualizada.Categoria;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo nome deve ser preenchido.");

        if (CargaHoraria <= 0)
            erros.Add("A carga horária do curso deve ser maior que zero.");

        if (!Enum.IsDefined(Nivel))
            erros.Add("O curso deve possuir um nível.");

        return erros;
    }
}