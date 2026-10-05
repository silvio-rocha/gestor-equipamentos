# Sistema de empréstimo de equipamentos

API HTTP em .NET e uma página simples para cadastrar equipamentos, consultar disponibilidade e registrar empréstimos. A devolução e os demais casos podem ser demonstrados no Postman.

## Como iniciar

### Docker Compose (entrega)

Na pasta do projeto:

```bash
docker compose up --build
```

- Página: http://localhost:8080
- API: http://localhost:8080/equipamentos

Os dados ficam no volume `pgdata` do PostgreSQL. Depois de `docker compose down` e `docker compose up`, cadastros e empréstimos ativos continuam lá.

Para ver o log de uma chamada:

```bash
docker compose logs api
```

### Sem Docker (desenvolvimento local)

Requer o SDK .NET 10.

```bash
dotnet run --project src/Api
```

A página abre em http://localhost:5080. Neste modo o banco é um arquivo SQLite em `src/Api/data/app.db`.

## Rotas da API

| Método | Rota | Uso |
|---|---|---|
| `POST` | `/equipamentos` | Cadastra um equipamento |
| `GET` | `/equipamentos` | Lista equipamentos e o status atual |
| `POST` | `/equipamentos/{id}/emprestimos` | Registra um empréstimo |
| `POST` | `/equipamentos/{id}/devolucao` | Registra a devolução |

`POST` cria um recurso ou dispara uma ação (empréstimo/devolução). `GET` só lê. Não há `PUT`/`PATCH` nesta versão porque não há edição de cadastro.

### Cadastrar

```http
POST /equipamentos
Content-Type: application/json

{ "codigo": "NB-01", "nome": "Notebook Dell" }
```

`201` em sucesso. `400` se faltar código ou nome. `409` se o código já existir.

### Listar

```http
GET /equipamentos
```

`200` com `status` `disponivel` ou `emprestado`. Se estiver emprestado, vem também `emprestimo.pessoa`.

### Emprestar

```http
POST /equipamentos/1/emprestimos
Content-Type: application/json

{ "pessoa": "Ana Souza" }
```

`201` em sucesso. `400` se faltar o nome da pessoa. `404` se o id não existir. `409` se o equipamento já estiver emprestado. Essa regra está em `src/Api/Services/EmprestimoService.cs`, no método `EmprestarAsync`.

### Devolver

```http
POST /equipamentos/1/devolucao
```

`200` em sucesso. `404` se o id não existir. `409` se o equipamento não estiver emprestado.

Requests Postman: pasta `postman/Empréstimo de equipamentos/` (`baseUrl` padrão `http://localhost:8080`). Sem Docker, troque `baseUrl` para `http://localhost:5080`.
