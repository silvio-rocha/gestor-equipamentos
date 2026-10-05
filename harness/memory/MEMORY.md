# Convenções de memória

Só convenções. ≤ ~80 linhas. Fatos de sessão vão em `active-context.md` e `sessions/`. Sem transcript.

## O que gravar

- Decisões e o porquê em uma linha.
- Vereditos (seguir / refinar / descartar) e data.
- Nomes estáveis: workspace, skills, arquivos deste harness.
- Preferências do Silvio que se repetem.

## O que não gravar

- Transcript, logs de chat, “o usuário disse…”.
- Código de produto, dumps, TODOs inflados.
- Segredos, `.env`, credenciais.

## Arquivos

| Path | Papel | Limite |
|---|---|---|
| `active-context.md` | Onde paramos | ~100 linhas |
| `idea-context.md` | Grill em curso | enxuto |
| `sessions/YYYY-MM-DD.md` | Recap do dia | um arquivo/dia; append |
| `MEMORY.md` | Este arquivo | ~80 linhas |

## Handoff

Só skill `session-handoff`. Escrita mescla convenções novas aqui (dedupe, corte o que passou do limite). Leitura não inventa estado.

## Skills

Editar em `harness/skills/`. Nunca nas junctions. Skill nova: `harness-add-skill` se o usuário pedir.

## Fase 0 / 1

Fase 0 = grill até veredito. Fase 1 só após **seguir**. Não implementar skills futuras agora.

## Tom

PT-BR. Curto. Imperativo para o agente. Sem encher contexto.
