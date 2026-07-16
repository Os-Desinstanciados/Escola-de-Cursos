using System.Runtime.CompilerServices;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

public record ListarTurmasDto(
    Guid Id,
    string Nome,
    DateTime DataInicio,
    DateTime DataTermino,
    int NumeroMaximoAlunos,
    Guid InstrutorId,
    string InstrutorNome    
);

public record CadastrarTurmaDto(
    string Nome,
    DateTime DataInicio,
    DateTime DataTermino,
    int NumeroMaximoAlunos,
    Guid InstrutorId    
);

public record EditarTurmaDto(
    Guid Id,
    string Nome,
    DateTime DataInicio,
    DateTime DataTermino,
    int NumeroMaximoAlunos,
    Guid InstrutorId    
);

public record DetalhesTurmaDto(
    Guid Id,
    string Nome,
    DateTime DataInicio,
    DateTime DataTermino,
    int NumeroMaximoAlunos,
    Guid InstrutorId,
    string InstrutorNome
);

public record OpcaoInstrutorDto(Guid Id, string Nome);
