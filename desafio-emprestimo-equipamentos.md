# Desafio: sistema de empréstimo de equipamentos

**Tempo de implementação:** 3 horas  
**Ferramenta de desenvolvimento:** Cursor gratuito, com uso de IA permitido  
**Objetivo:** construir, executar e explicar um sistema pequeno que funcione localmente.

## O problema

Uma equipe empresta notebooks e projetores, mas hoje controla tudo em uma planilha. Às vezes, o mesmo equipamento aparece emprestado para duas pessoas ao mesmo tempo, e fica difícil saber o que está disponível.

Crie um sistema para cadastrar equipamentos, consultar a disponibilidade, registrar empréstimos e registrar devoluções. O sistema deve impedir que um equipamento tenha dois empréstimos ativos ao mesmo tempo.

## Requisitos

### Funcionais

- Cadastrar um equipamento com, no mínimo, um código único e um nome.
- Consultar a lista de equipamentos e identificar quais estão disponíveis ou emprestados.
- Registrar o empréstimo de um equipamento para uma pessoa.
- Registrar a devolução de um equipamento emprestado.
- Recusar um novo empréstimo quando o equipamento já estiver emprestado.
- Informar erros de entrada e situações inválidas de forma compreensível.

Nesta primeira versão, basta acompanhar a situação atual dos equipamentos e empréstimos. O histórico completo de empréstimos fica para uma evolução posterior.

### Técnicos

- Criar uma API HTTP em .NET que troque dados em JSON.
- Criar uma página simples em JavaScript ou TypeScript que use a API para consultar equipamentos e iniciar um empréstimo.
- Demonstrar a devolução e outros casos usando o Postman.
- Executar o sistema localmente com Docker Compose.
- Persistir os dados: depois de parar e iniciar os contêineres, os equipamentos e empréstimos continuam registrados.
- Escolher rotas e verbos HTTP adequados para as operações. Você deverá explicar suas escolhas; não é necessário usar todos os verbos HTTP.

A aparência da página não será avaliada. Ela precisa apenas permitir demonstrar a comunicação com a API.

## Demonstração

Antes de publicar o repositório, mostre o sistema funcionando na sua máquina:

1. Inicie os serviços com Docker Compose e abra a página.
2. Cadastre equipamentos e consulte a disponibilidade.
3. Registre um empréstimo e tente emprestar o mesmo equipamento novamente.
4. Registre a devolução e consulte a disponibilidade de novo.
5. Use o Postman para mostrar uma requisição e uma resposta, incluindo método, endereço, cabeçalhos, corpo e status HTTP.
6. Consulte os logs do contêiner e explique o que aconteceu em uma das chamadas.
7. Reinicie os serviços e confirme que os dados continuam salvos.

## Entrega

- Código-fonte do sistema.
- Arquivos necessários para executá-lo com Docker Compose.
- Um `README.md` com os passos para iniciar o projeto e exemplos de uso da API.
- Link para o repositório depois da demonstração local.

## Uso de IA

Você pode usar IA durante todo o desenvolvimento. Você continua responsável por verificar o código e explicar como o sistema funciona. Durante a demonstração, esteja preparado para apontar onde a regra que impede empréstimos duplicados foi implementada e contar um exemplo de sugestão da IA que você precisou conferir ou ajustar.

## Evoluções para depois da primeira validação

O primeiro desafio não exige histórico completo de empréstimos, autenticação ou publicação na nuvem. Depois de validar esta versão, o sistema poderá evoluir com testes automatizados, histórico de empréstimos e novas regras.
