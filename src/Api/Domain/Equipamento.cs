namespace Api.Domain;

public sealed class Equipamento
{
    public int Id { get; set; }
    public required string Codigo { get; set; }
    public required string Nome { get; set; }
    public Emprestimo? EmprestimoAtivo { get; set; }
}
