---
name: grill-me
description: >-
  Questiona uma ideia até veredito seguir, refinar ou descartar. Sem código.
  Usar quando a ideia for vaga, o usuário disser "me questiona", "grill",
  "fase 0", ou pedir para validar/desmontar a ideia.
---

# grill-me

Fase 0. Sem código, sem app, sem specs. Um turno = uma pergunta (ou um veredito).

Ler `harness/memory/idea-context.md` e `harness/memory/active-context.md` antes de falar.

## Rotas

- Sem as 3 respostas (problema, público, por que agora) → **Modo A**.
- Com as 3, ou usuário já trouxe a ideia estruturada → **Modo B**.
- Usuário pede veredito agora → fechar veredito com o que houver.

## Modo A

Três perguntas, **uma por mensagem**, nesta ordem:

1. Qual problema, em uma frase, para quem dói hoje?
2. Quem é o público e por que pagaria/usaria?
3. Por que agora (e o que já tentou)?

Depois de cada resposta, gravar em `harness/memory/idea-context.md` (seção Modo A). Sem resumão longo.

Ao fechar as 3, ir ao **Modo B** na mesma sessão (primeira pergunta do ramo mais fraco).

## Modo B

Um ramo por vez. Não listar árvore. Escolher o pressuposto mais fraco e pressionar: evidência, alternativa óbvia, custo de estar errado.

Gravar em `idea-context.md`: ramo, resposta, o que ainda não foi testado.

Repetir até conseguir veredito. Sem implementar nada.

## Veredito

Um de: **seguir** | **refinar** | **descartar**. Uma linha de porquê.

- **seguir** — atualizar `idea-context.md` e `active-context.md` (fase 0 concluída; Fase 1 à escolha do usuário). Não começar Fase 1 sozinho.
- **refinar** — o que falta; próxima pergunta; permanece Fase 0.
- **descartar** — porquê; limpar próximo passo da ideia.

Não gravar transcript. Só fatos.
