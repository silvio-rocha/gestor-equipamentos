---
name: harness-add-skill
description: >-
  Cria uma skill nova neste harness (harness/skills/<kebab>/SKILL.md) e
  atualiza harness/SKILLS.md. Usar só quando o usuário pedir skill nova
  no harness.
disable-model-invocation: true
---

# harness-add-skill

Só se o usuário pedir skill nova **neste** repo. Não inventar skill. Não criar `harness-audit`. Não implementar Fase 1.

Fonte da verdade: `harness/skills/`. Nunca escrever em `.cursor/skills/` nem `.agents/skills/`.

Antes de redigir, ler [references/authoring.md](references/authoring.md).

## Passos

1. Nome kebab-case (max 64). Confirmar se ambíguo.
2. Criar `harness/skills/<kebab>/SKILL.md` (frontmatter `name` + `description` WHAT+WHEN, terceira pessoa).
3. `disable-model-invocation: true` se for skill rara/perigosa; omitir se deve auto-disparar por frase.
4. Corpo curto, passos, paths deste harness. Sem produto.
5. Atualizar a tabela em `harness/SKILLS.md`.
6. Não commitar a menos que o usuário peça.

## Não fazer

- Copiar skill para as junctions.
- Criar `app/`, `specs/`.
- Inchar `MEMORY.md` com o tutorial da skill.
