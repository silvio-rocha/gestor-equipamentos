# Authoring de skills (harness)

## Layout

```
harness/skills/<kebab>/
  SKILL.md
  references/          # opcional, um nível
```

Junctions apontam para `harness/skills/`. Editar só aqui.

## Frontmatter

- `name`: igual à pasta, `[a-z0-9-]+`, max 64
- `description`: max 1024, terceira pessoa, o quê + quando (frases-gatilho)
- `disable-model-invocation: true` se não deve auto-invocar

## Corpo

- < 500 linhas; o essencial no SKILL.md
- Referências um nível abaixo, linkadas do SKILL.md
- Paths POSIX no texto (`harness/skills/...`)
- PT-BR, curto, acionável
- Sem transcript; memória só em `harness/memory/`

## Padrão deste cérebro

Skills atuais: `grill-me`, `session-handoff`, `harness-add-skill`.  
Fase 0 não ganha skill de build/SDD agora.
