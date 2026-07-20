using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public record ListarCategoriaViewModel(
    Guid Id,
    string Nome
);

public record CadastrarCategoriaViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(35, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 35 caracteres.")]
    string Nome
);

public record EditarCategoriaViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(35, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 35 caracteres.")]
    string Nome
);

public record ExcluirCategoriaViewModel(
    Guid Id,
    string Nome
);