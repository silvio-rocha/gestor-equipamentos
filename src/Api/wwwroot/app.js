const mensagem = document.querySelector("#mensagem");
const lista = document.querySelector("#lista");
const formCadastro = document.querySelector("#form-cadastro");

function mostrar(texto, tipo) {
  mensagem.textContent = texto;
  mensagem.className = tipo;
}

async function lerJson(resposta) {
  const corpo = await resposta.json().catch(() => ({}));
  if (!resposta.ok) {
    throw new Error(corpo.erro || `Erro HTTP ${resposta.status}`);
  }
  return corpo;
}

async function carregar() {
  const equipamentos = await lerJson(await fetch("/equipamentos"));
  lista.replaceChildren();

  if (equipamentos.length === 0) {
    const linha = document.createElement("tr");
    linha.innerHTML = `<td colspan="5">Nenhum equipamento cadastrado.</td>`;
    lista.append(linha);
    return;
  }

  for (const item of equipamentos) {
    const linha = document.createElement("tr");
    const ocupado = item.status === "emprestado";
    const comQuem = ocupado ? item.emprestimo.pessoa : "—";
    const acao = ocupado
      ? `<span>Indisponível</span>`
      : `<form class="emprestar" data-id="${item.id}">
           <input name="pessoa" required maxlength="200" placeholder="Nome da pessoa">
           <button type="submit">Emprestar</button>
         </form>`;

    linha.innerHTML = `
      <td>${item.codigo}</td>
      <td>${item.nome}</td>
      <td class="${item.status}">${ocupado ? "Emprestado" : "Disponível"}</td>
      <td>${comQuem}</td>
      <td>${acao}</td>`;
    lista.append(linha);
  }

  lista.querySelectorAll("form.emprestar").forEach((form) => {
    form.addEventListener("submit", emprestar);
  });
}

async function cadastrar(evento) {
  evento.preventDefault();
  const dados = new FormData(formCadastro);
  try {
    await lerJson(await fetch("/equipamentos", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        codigo: dados.get("codigo"),
        nome: dados.get("nome")
      })
    }));
    formCadastro.reset();
    mostrar("Equipamento cadastrado.", "ok");
    await carregar();
  } catch (erro) {
    mostrar(erro.message, "erro");
  }
}

async function emprestar(evento) {
  evento.preventDefault();
  const form = evento.currentTarget;
  const id = form.dataset.id;
  const pessoa = new FormData(form).get("pessoa");
  try {
    await lerJson(await fetch(`/equipamentos/${id}/emprestimos`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ pessoa })
    }));
    mostrar("Empréstimo registrado.", "ok");
    await carregar();
  } catch (erro) {
    mostrar(erro.message, "erro");
  }
}

formCadastro.addEventListener("submit", cadastrar);
carregar().catch((erro) => mostrar(erro.message, "erro"));
