using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutor;

public record ListarInstrutoresViewModel(
    Guid Id,
    string Nome,
    string Endereco,
    string Telefone,
    string Email
);

public record CadastrarInstrutorViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Endereço\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Endereço\" deve conter entre 2 e 100 caracteres.")]
    string Endereco,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.")]
    string Telefone,
    
    [Required(ErrorMessage = "O campo \"E-mail\" deve ser preenchido.")]
    [EmailAddress(ErrorMessage = "O campo \"E-mail\" deve conter um endereço de e-mail válido.")]
    string Email
);

public record EditarInstrutorViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Endereço\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Endereço\" deve conter entre 2 e 100 caracteres.")]
    string Endereco,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.")]
    string Telefone,
    
    [Required(ErrorMessage = "O campo \"E-mail\" deve ser preenchido.")]
    [EmailAddress(ErrorMessage = "O campo \"E-mail\" deve conter um endereço de e-mail válido.")]
    string Email
);

public record ExcluirInstrutorViewModel(
    Guid Id,
    string Nome,
    string Endereco,
    string Telefone,
    string Email
);