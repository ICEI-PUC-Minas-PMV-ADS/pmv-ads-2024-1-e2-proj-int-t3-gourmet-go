# Especificações do Projeto

## Personas

![m1 (1)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/assets/116202867/c0b9d9a2-356d-425f-8bf5-f213591c3f23)

Sofia é uma empreendedora de 39 anos, apaixonada por gastronomia, que possui um restaurante familiar em um bairro tradicional de São Paulo. Ela busca meios de trazer popularidade e um gerenciamento mais dinâmico para seu restaurante. Atingindo assim um público maior para dar continuidade ao legado da família. Seus hobbies favoritos são cozinhar e viajar, ela também ama compartilhar suas trajetórias em suas redes sociais.

![h1 (1)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/assets/116202867/6591b21a-f304-4907-b3cb-880455b03b01)

Carlos Alberto é um cozinheiro de 28 anos em ascensão, é casado e tem um filho de 3 anos. Tem por objetivo de vida levar alegria e conforto através de seus pratos, sempre busca conehcimento e estuda todos os seus pratos de forma metódica, para garantir excelencia em seu trabalho.
Ama leitura  e conhecimentos gerais sobre culinária asiática. Em suas horas livres ele gosta de viajar em família, e praticar pescaria com seu filho.

![h2 (1)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/assets/116202867/0d6e5e59-8369-48cd-85b5-c213fed0a48d)

Henrique é um garçom de 19 anos, recém contratado e está sempre atualizado na tecnologia, pois acredita que assim pode garantir um trabalho mais eficiente. Ele estuda música e artes cênicas , pois é a sua paixão se expressar através da arte.

![m2 (1)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/assets/116202867/dba0705c-9bc6-4bac-8d82-00e7a4af5173)

Angêla é uma advogada de 44 anos de renome em seu estado, casada e sem filhos. Sua vida é muita agitada e corrida , quase não sobre tempo para fazer uma alimentação saudável, sendo assim ela tem um carinho especial por delivery e restaurantes com trabalho rapido e eficiente. Seus hobby é leitura, mas ama também viajar com seu marido e colecionar itens de todos os lugares por onde já passou.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`|        QUERO/PRECISO ... `FUNCIONALIDADE`                                          |                                    PARA ... `MOTIVO/VALOR`                               |
|--------------------|------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------|
|Proprietário        | Criar, alterar e editar cadstro de fucioários                                      |Manter os registros atualizados                                                           |
|Proprietário        | Criar, editar e vizualizar cardápio do restaurante                                 |Manter os pratos disponíveis atualizados                                                  |
|Cozinheiro          | Vizualizar pedidos em tempo real                                                   |Para uma coordenação de equipe eficaz entre a cozinha e atendimento ao cliente            |
|Cozinheiro          | Vizualizar e alterar estoque                                                       |Para garantir disponibilidade de ingredientes                                             |
|Garçom              | Receber notificações de novos pedidos e atualizações sobre status dos pedidos      |Para atender rapidamente os pedidos                                                       |
|Cliente             | Realizar pedido por delivery ou no restaurante                                     |Para ter mais comodidade e facilidade na escolha                                          |
|Cliente             | Vizualizar e alterar itens do pedido                                               |Escolher facilmente o que pedir e planejar o meu orçamento                                | 


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
| RF-12 | A aplicação deve oferecer ao usuário (cliente) as formas de pagamento no app, no restaurante ou na entrega. | MÉDIA |
| RF-13 | A aplicação deve ser capaz de informar ao usuário (restaurante) sobre novos pedidos. | ALTA |
| RF-14 | A aplicação deve ser capaz de informar ao usuário (cliente) o status do pedido (pedido recebido, pedido em preparação, pedido finalizado, pedido saiu para entrega). | ALTA |
| RF-15 | A aplicação deve disponibilizar aos usuários (cliente e restaurante) o histórico completo de pedidos do cliente. | BAIXA |

** Prioridade: Alta / Média / Baixa. 

### Requisitos Não Funcionais

|ID | Descrição | Prioridade |
|------|-----------------------------------------|----|
| RNF-01 | A aplicação deve ser publicada em um ambiente acessível público na Internet. | ALTA |
| RNF-02 | A aplicação deve estar disponível 24 horas por dia, 7 dias por semana. | ALTA |
| RNF-03 | A aplicação deve ser desenvolvida utilizando a plataforma .NET com a linguagem C#. | ALTA |
| RNF-04 | A aplicação deve utilizar o framework Entity Framework e o banco de dados SQL Server para gravação dos dados. | ALTA |
| RNF-05 | O tempo de resposta para gravação de um pedido não deve exceder a 3 segundos. | MÉDIA |
| RNF-06 | A aplicação deve ser compatível com os principais navegadores do mercado: Google Chrome, Safari, Firefox, Opera e Microsoft Edge. | ALTA |
| RNF-07 | A aplicação deve ser responsiva, permitindo a visualização em dispositivos diversos de forma adequada. | MÉDIA |

** Prioridade: Alta / Média / Baixa. 

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrições |
|--|-------------------------------------------------------|
| 01 | Todas as etapas do projeto devem ser entregues no prazo estipulado. |
| 02 | O projeto deve ser desenvolvido no padrão de arquitetura MVC. |
| 03 | A documentação e o código fonte da aplicação devem ser publicados no GitHub. |
| 04 | A equipe não pode subcontratar o desenvolvimento do projeto. |

## Diagrama de Casos de Uso

![Diagrama de Casos de Uso](img/gourmetgo-diagramacasosdeuso.png)
