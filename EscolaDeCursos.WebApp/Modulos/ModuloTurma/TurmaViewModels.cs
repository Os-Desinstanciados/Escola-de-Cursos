using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public record ListarTurmaViewModel(
    Guid Id,
    string Nome,
    DateTime DataInicio,
    DateTime DataTermino,
    int NumeroMaximoAlunos,
    Guid InstrutorId,
    string InstrutorNome
);

public record CadastrarTurmaViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Data de Início\" deve ser preenchido.")]
    [DataType(DataType.Date)]
    DateTime DataInicio,

    [Required(ErrorMessage = "O campo \"Data de Término\" deve ser preenchido.")]
    [DataType(DataType.Date)]
    DateTime DataTermino,

    [Range(0.01, double.MaxValue, ErrorMessage = "O campo \"Número Máximo de Alunos\" deve ser maior que zero.")]
    int NumeroMaximoAlunos,

    Guid InstrutorId,

    [ValidateNever]
    List<OpcaoInstrutorViewModel> Instrutores
);

public record EditarTurmaViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Data de Início\" deve ser preenchido.")]
    [DataType(DataType.Date)]
    DateTime DataInicio,

    [Required(ErrorMessage = "O campo \"Data de Término\" deve ser preenchido.")]
    [DataType(DataType.Date)]
    DateTime DataTermino,

    [Range(0.01, double.MaxValue, ErrorMessage = "O campo \"Número Máximo de Alunos\" deve ser maior que zero.")]
    int NumeroMaximoAlunos,

    Guid InstrutorId,

    [ValidateNever]
    List<OpcaoInstrutorViewModel> Instrutores
);

public record ExcluirTurmaViewModel(
    Guid Id,
    string Nome,
    DateTime DataInicio,
    DateTime DataTermino,
    int NumeroMaximoAlunos,
    Guid InstrutorId,
    string InstrutorNome
);

public record OpcaoInstrutorViewModel(Guid Id, string Nome);