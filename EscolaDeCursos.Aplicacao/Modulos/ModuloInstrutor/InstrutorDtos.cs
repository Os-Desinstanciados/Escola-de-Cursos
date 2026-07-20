namespace EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;

public record ListarInstrutoresDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);

public record CadastrarInstrutorDto(
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);

public record EditarInstrutorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);

public record DetalhesInstrutorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);