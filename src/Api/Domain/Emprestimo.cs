namespace Api.Domain;

public sealed class Emprestimo
{
    public int Id { get; set; }
    public int EquipamentoId { get; set; }
    public Equipamento Equipamento { get; set; } = null!;
    public required string Pessoa { get; set; }
    public DateTimeOffset DataEmprestimo { get; set; }
}
