namespace Api.Dtos;

public sealed record CriarEquipamentoRequest(string? Codigo, string? Nome);

public sealed record CriarEmprestimoRequest(string? Pessoa);

public sealed record EmprestimoResponse(string Pessoa, DateTimeOffset DataEmprestimo);

public sealed record EquipamentoResponse(
    int Id,
    string Codigo,
    string Nome,
    string Status,
    EmprestimoResponse? Emprestimo);

public sealed record ErroResponse(string Erro);
