---
name: session-handoff
description: >-
  Salva ou retoma o estado entre chats. Usar quando o usuário disser
  "salvar sessão", "onde paramos", "pausar", "handoff", "retomar",
  ou ao encerrar trabalho que precisa sobreviver ao chat.
---

# session-handoff

Handoff só por esta skill. Sem transcript. Só fatos.

Paths:

- `harness/memory/active-context.md`
- `harness/memory/MEMORY.md`
- `harness/memory/idea-context.md`
- `harness/memory/sessions/YYYY-MM-DD.md` (data local)

## Escrita (salvar / pausar)

1. Recap do dia em `sessions/YYYY-MM-DD.md` (criar ou append). Template:

```markdown
## HH:MM
- Feito:
- Decisões:
- Aberto:
- Próximo:
```

2. Reescrever `active-context.md` (~100 linhas): fase, estado, decisões vigentes, bloqueios, próximo passo.
3. Se `idea-context.md` tiver conteúdo, mesclar o estável no recap e no active-context; não duplicar prosa.
4. Mesclar em `MEMORY.md` só convenções novas; dedupe; manter ~80 linhas.
5. Confirmar em 2–4 bullets o que foi gravado. Sem dump dos arquivos.

## Leitura (onde paramos / retomar)

1. Ler active-context, MEMORY, idea-context se não vazio, sessão de hoje e a mais recente se hoje vazio.
2. Responder com **3–5 bullets** + o próximo passo concreto.
3. Continuar o trabalho se o usuário quiser; não reabrir grill sem pedido.

## Proibido

- Colar conversa, logs, ou “o modelo disse”.
- Inventar decisões.
- Editar skills pelas junctions.
