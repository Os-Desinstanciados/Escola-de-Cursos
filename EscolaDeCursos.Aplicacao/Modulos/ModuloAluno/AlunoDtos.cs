namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public record ListarAlunosDto(
    Guid Id,
    string Nome,
    string Endereco,
    string Telefone,
    string Email
);

public record CadastrarAlunoDto(
    string Nome,
    string Endereco,
    string Telefone,
    string Email
);

public record EditarAlunoDto(
    Guid Id,
    string Nome,
    string Endereco,
    string Telefone,
    string Email
);

public record DetalhesAlunoDto(
    Guid Id,
    string Nome,
    string Endereco,
    string Telefone,
    string Email
);