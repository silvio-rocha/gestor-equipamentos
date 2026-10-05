using Api.Data;
using Api.Domain;
using Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public sealed class EmprestimoService(AppDbContext db)
{
    public async Task<IReadOnlyList<EquipamentoResponse>> ListarAsync(CancellationToken ct)
    {
        var itens = await db.Equipamentos
            .AsNoTracking()
            .Include(e => e.EmprestimoAtivo)
            .OrderBy(e => e.Codigo)
            .ToListAsync(ct);

        return itens.Select(ParaResposta).ToList();
    }

    public async Task<(int Status, object Body)> CadastrarAsync(CriarEquipamentoRequest request, CancellationToken ct)
    {
        var codigo = request.Codigo?.Trim() ?? "";
        var nome = request.Nome?.Trim() ?? "";

        if (codigo.Length == 0 || nome.Length == 0)
            return (400, new ErroResponse("Informe código e nome do equipamento."));

        if (await db.Equipamentos.AnyAsync(e => e.Codigo == codigo, ct))
            return (409, new ErroResponse($"Já existe um equipamento com o código '{codigo}'."));

        var equipamento = new Equipamento { Codigo = codigo, Nome = nome };
        db.Equipamentos.Add(equipamento);

        try
        {
            await db.SaveChangesAsync(ct);
        }
        catch (DbUpdateException)
        {
            return (409, new ErroResponse($"Já existe um equipamento com o código '{codigo}'."));
        }

        return (201, ParaResposta(equipamento));
    }

    public async Task<(int Status, object Body)> EmprestarAsync(int id, CriarEmprestimoRequest request, CancellationToken ct)
    {
        var pessoa = request.Pessoa?.Trim() ?? "";
        if (pessoa.Length == 0)
            return (400, new ErroResponse("Informe o nome da pessoa que vai receber o equipamento."));

        var equipamento = await db.Equipamentos
            .Include(e => e.EmprestimoAtivo)
            .FirstOrDefaultAsync(e => e.Id == id, ct);

        if (equipamento is null)
            return (404, new ErroResponse("Equipamento não encontrado."));

        // Regra central do desafio: um equipamento não pode ter dois empréstimos ativos.
        if (equipamento.EmprestimoAtivo is not null)
            return (409, new ErroResponse("Este equipamento já está emprestado."));

        equipamento.EmprestimoAtivo = new Emprestimo
        {
            Pessoa = pessoa,
            DataEmprestimo = DateTimeOffset.UtcNow
        };

        try
        {
            await db.SaveChangesAsync(ct);
        }
        catch (DbUpdateException)
        {
            return (409, new ErroResponse("Este equipamento já está emprestado."));
        }

        return (201, ParaResposta(equipamento));
    }

    public async Task<(int Status, object Body)> DevolverAsync(int id, CancellationToken ct)
    {
        var equipamento = await db.Equipamentos
            .Include(e => e.EmprestimoAtivo)
            .FirstOrDefaultAsync(e => e.Id == id, ct);

        if (equipamento is null)
            return (404, new ErroResponse("Equipamento não encontrado."));

        if (equipamento.EmprestimoAtivo is null)
            return (409, new ErroResponse("Este equipamento não está emprestado."));

        db.Emprestimos.Remove(equipamento.EmprestimoAtivo);
        await db.SaveChangesAsync(ct);

        equipamento.EmprestimoAtivo = null;
        return (200, ParaResposta(equipamento));
    }

    public async Task<(int Status, object? Body)> ExcluirAsync(int id, CancellationToken ct)
    {
        var equipamento = await db.Equipamentos
            .Include(e => e.EmprestimoAtivo)
            .FirstOrDefaultAsync(e => e.Id == id, ct);

        if (equipamento is null)
            return (404, new ErroResponse("Equipamento não encontrado."));

        if (equipamento.EmprestimoAtivo is not null)
            return (409, new ErroResponse("Devolva o equipamento antes de excluir."));

        db.Equipamentos.Remove(equipamento);
        await db.SaveChangesAsync(ct);
        return (204, null);
    }

    private static EquipamentoResponse ParaResposta(Equipamento equipamento)
    {
        var emprestimo = equipamento.EmprestimoAtivo is null
            ? null
            : new EmprestimoResponse(
                equipamento.EmprestimoAtivo.Pessoa,
                equipamento.EmprestimoAtivo.DataEmprestimo);

        return new EquipamentoResponse(
            equipamento.Id,
            equipamento.Codigo,
            equipamento.Nome,
            emprestimo is null ? "disponivel" : "emprestado",
            emprestimo);
    }
}
