# Skills

Fonte: `harness/skills/<nome>/SKILL.md`. Junctions não são fonte.

| Skill | Quando | Auto |
|---|---|---|
| `grill-me` | Ideia vaga, “me questiona”, Fase 0 | sim |
| `session-handoff` | “salvar sessão”, “onde paramos”, pausar, retomar | sim |
| `harness-add-skill` | Usuário pede skill nova **neste** harness | não (`disable-model-invocation`) |

## grill-me

Modo A: 3 perguntas uma a uma (problema, público, por que agora) → `idea-context.md` → Modo B.  
Modo B: um ramo por vez até veredito seguir / refinar / descartar. Sem código.

## session-handoff

Escrita: `sessions/YYYY-MM-DD.md` + `active-context.md` + mesclar `MEMORY.md` e `idea-context.md` se houver.  
Leitura: esses arquivos → 3–5 bullets → continuar. Sem transcript.

## harness-add-skill

Criar `harness/skills/<kebab>/SKILL.md`, atualizar esta tabela. Ver `harness/skills/harness-add-skill/references/authoring.md`.
