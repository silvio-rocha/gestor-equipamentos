# HARNESS — gestor-equipamentos

Contrato do cérebro. Sem código de produto neste repo.

## Loop

1. Chat inicia → ler `harness/memory/active-context.md`.
2. Trabalho → fatos na memória, nunca transcript.
3. Pausa → `session-handoff` (escrita).
4. Retomada → `session-handoff` (leitura) ou a rule já leu o contexto ativo.

## Fases

Ver `harness/docs/phases.md`.

- **Fase 0:** `grill-me` até veredito seguir / refinar / descartar.
- **Fase 1:** só depois do veredito seguir. Docs informal **ou** SDD **ou** build — o usuário escolhe. Skills futuras dessa fase não implementar agora.

## Regras

- Handoff só pela skill `session-handoff`.
- `active-context.md` ≤ ~100 linhas.
- `MEMORY.md` ≤ ~80 linhas, só convenções.
- Skill nova no harness: só se pedida, via `harness-add-skill`.
- Não criar `harness-audit`, `specs/`, `app/`.
