using Api.Dtos;
using Api.Services;

namespace Api.Endpoints;

public static class EquipamentoEndpoints
{
    public static void MapEquipamentoEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/equipamentos");

        group.MapGet("/", async (EmprestimoService service, CancellationToken ct) =>
        {
            var lista = await service.ListarAsync(ct);
            return Results.Ok(lista);
        });

        group.MapPost("/", async (CriarEquipamentoRequest request, EmprestimoService service, CancellationToken ct) =>
        {
            var (status, body) = await service.CadastrarAsync(request, ct);
            return Results.Json(body, statusCode: status);
        });

        group.MapPost("/{id:int}/emprestimos", async (int id, CriarEmprestimoRequest request, EmprestimoService service, CancellationToken ct) =>
        {
            var (status, body) = await service.EmprestarAsync(id, request, ct);
            return Results.Json(body, statusCode: status);
        });

        group.MapPost("/{id:int}/devolucao", async (int id, EmprestimoService service, CancellationToken ct) =>
        {
            var (status, body) = await service.DevolverAsync(id, ct);
            return Results.Json(body, statusCode: status);
        });

        group.MapDelete("/{id:int}", async (int id, EmprestimoService service, CancellationToken ct) =>
        {
            var (status, body) = await service.ExcluirAsync(id, ct);
            return body is null ? Results.NoContent() : Results.Json(body, statusCode: status);
        });
    }
}
