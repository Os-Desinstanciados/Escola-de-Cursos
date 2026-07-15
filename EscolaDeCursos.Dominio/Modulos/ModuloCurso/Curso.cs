using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCurso;

public class Curso : EntidadeBase<Curso>
{
    public string Nome { get; set; } = string.Empty;

    public Guid CategoriaId { get; set; }

    public Categoria? Categoria { get; set; }

    public NivelCurso Nivel { get; set; }

    public int CargaHoraria { get; set; }

    public Curso()
    {
    }

    public override void Atualizar(Curso entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        CategoriaId = entidadeAtualizada.CategoriaId;
        Nivel = entidadeAtualizada.Nivel;
        CargaHoraria = entidadeAtualizada.CargaHoraria;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo nome deve ser preenchido.");

        if (CategoriaId == Guid.Empty)
            erros.Add("O curso deve possuir uma categoria.");

        if (CargaHoraria <= 0)
            erros.Add("A carga horária do curso deve ser maior que zero.");

        if (Nivel == NivelCurso.NaoDefinido)
            erros.Add("O curso deve possuir um nível.");
            
        return erros;
    }
}