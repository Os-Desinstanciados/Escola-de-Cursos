namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public record ListarAlunosDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string NumeroMatricula
);

public record CadastrarAlunoDto(
    string Nome,
    string Telefone,
    string Email
);

public record EditarAlunoDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);

public record DetalhesAlunoDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string NumeroMatricula
);