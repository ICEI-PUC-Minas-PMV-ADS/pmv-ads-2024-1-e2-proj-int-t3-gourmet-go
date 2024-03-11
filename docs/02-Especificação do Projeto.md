# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

Pedro Paulo tem 26 anos, é arquiteto recém-formado e autônomo. Pensa em se desenvolver profissionalmente através de um mestrado fora do país, pois adora viajar, é solteiro e sempre quis fazer um intercâmbio. Está buscando uma agência que o ajude a encontrar universidades na Europa que aceitem alunos estrangeiros.

Enumere e detalhe as personas da sua solução. Para tanto, baseie-se tanto nos documentos disponibilizados na disciplina e/ou nos seguintes links:

> **Links Úteis**:
> - [Rock Content](https://rockcontent.com/blog/personas/)
> - [Hotmart](https://blog.hotmart.com/pt-br/como-criar-persona-negocio/)
> - [O que é persona?](https://resultadosdigitais.com.br/blog/persona-o-que-e/)
> - [Persona x Público-alvo](https://flammo.com.br/blog/persona-e-publico-alvo-qual-a-diferenca/)
> - [Mapa de Empatia](https://resultadosdigitais.com.br/blog/mapa-da-empatia/)
> - [Mapa de Stalkeholders](https://www.racecomunicacao.com.br/blog/como-fazer-o-mapeamento-de-stakeholders/)
>
Lembre-se que você deve ser enumerar e descrever precisamente e personalizada todos os clientes ideais que sua solução almeja.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Usuário do sistema  | Registrar minhas tarefas           | Não esquecer de fazê-las               |
|Administrador       | Alterar permissões                 | Permitir que possam administrar contas |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.

> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID | Descrição | Prioridade |
|------|-----------------------------------------|----|
| RF-01 | A aplicação deve permitir aos usuários (cliente e restaurante) cadastrar, visualizar, editar e excluir uma conta de acesso ao sistema. | ALTA |
| RF-02 | A aplicação deve permitir aos usuários (cliente e restaurante) realizar login/logout no sistema. | ALTA |
| RF-03 | A aplicação deve permitir aos usuários (cliente e restaurante) recuperar sua senha de acesso ao sistema. | BAIXA |
| RF-04 | A aplicação deve permitir ao usuário (restaurante) cadastrar, visualizar, editar e excluir produtos do cardápio. | ALTA | 
| RF-05 | A aplicação deve permitir ao usuário (cliente) cadastrar, visualizar, editar e excluir endereços alternativos para entrega. | MÉDIA |
| RF-06 | A aplicação deve exibir ao usuário (cliente) o cardápio do restaurante. | ALTA |
| RF-07 | A aplicação deve informar ao usuário (cliente) se o restaurante encontra-se aberto ou fechado. | ALTA |
| RF-08 | A aplicação deve permitir ao usuário (cliente) adicionar, visualizar, editar e excluir itens à sacola. | ALTA |
| RF-09 | A aplicação deve ser capaz de intermediar compras entre cliente e restaurante. | ALTA |
| RF-10 | A aplicação deve permitir ao usuário (cliente) escolher entre retirar o pedido no restaurante ou receber via delivery. | ALTA |
| RF-11 | A aplicação deve permitir ao usuário (cliente) realizar pagamentos sem sair do aplicativo. | ALTA |
| RF-12 | A aplicação deve oferecer ao usuário (cliente) as formas de pagamento por cartão de crédito ou pix. | MÉDIA |
| RF-13 | A aplicação deve ser capaz de informar ao usuário (restaurante) sobre novos pedidos. | ALTA |
| RF-14 | A aplicação deve ser capaz de informar ao usuário (cliente) o status do pedido (pedido recebido, pedido em preparação, pedido finalizado, pedido saiu para entrega). | ALTA |
| RF-15 | A aplicação deve disponibilizar aos usuários (cliente e restaurante) o histórico completo de pedidos do cliente. | BAIXA |

** Prioridade: Alta / Média / Baixa. 

### Requisitos Não Funcionais

|ID | Descrição | Prioridade |
|------|-----------------------------------------|----|
| RNF-01 | A aplicação deve ser publicada em um ambiente acessível público na Internet. | ALTA |
| RNF-02 | A aplicação deve estar disponível 24 horas por dia, 7 dias por semana | ALTA |
| RNF-03 | A aplicação deve ser desenvolvida utilizando a plataforma .NET com a linguagem C# | ALTA |
| RNF-04 | A aplicação deve utilizar o framework Entity Framework e o banco de dados SQL Server para gravação dos dados. | ALTA |
| RNF-05 | O tempo de resposta para gravação de um pedido não deve exceder a 3 segundos. | MÉDIA |
| RNF-06 | A aplicação deve ser compatível com os principais navegadores do mercado: Google Chrome, Safari, Firefox, Opera e Microsoft Edge. | ALTA |
| RNF-07 | A aplicação deve ser responsiva, permitindo a visualização em dispositivos diversos de forma adequada. | MÉDIA |

** Prioridade: Alta / Média / Baixa. 

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |
|03| Limitação quanto ao uso de frameworks                 |

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
