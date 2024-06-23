# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

| **Caso de Teste** 	| **CT-01 – Cadastrar perfil** 	|
|:---:	|:---:	|
|	**Requisito Associado**| RF-01 - A aplicação deve permitir aos usuários (cliente e restaurante) cadastrar, visualizar, editar e excluir uma conta de acesso ao sistema.|
|	                       | RF-02 - A aplicação deve permitir aos usuários (cliente e restaurante) realizar login/logout no sistema.                                      | 
|                        | RF-03 - A aplicação deve permitir aos usuários (cliente e restaurante) recuperar sua senha de acesso ao sistema.|
|Registro de evidência | [Cadastrar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/blob/main/src/GourmetGo/Views/Usuarios/Cadastro.cshtml) / [Login](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/blob/main/src/GourmetGo/Views/Usuarios/Login.cshtml) / [Recuperar-Senha](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/blob/main/src/GourmetGo/Views/Home/EsqueciSenha.cshtml) |

![Login](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/blob/main/docs/img/login.png)



| **Caso de Teste** 	|**CT-02– Visualização das informações do restaurante** 	|
|:---:	|:---:	|
|                       |RF-01 - A aplicação deve exibir ao usuário (cliente) o cardápio do restaurante.|
|**Requisito Associado**|RF-02 - A aplicação deve informar ao usuário (cliente) se o restaurante se encontra aberto ou fechado.| 
|                       | 
|Registro de evidência |[Usuario](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/tree/main/src/GourmetGo/Views/Usuarios) |

![Restaurante](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/blob/main/docs/img/Restaurante.png)

| **Caso de Teste** 	|**CT-03– Escolha de seus itens e finalização** 	|
|:---:	|:---:	|
|**Requisitos Associados**|RF-01 - A aplicação deve permitir ao usuário (cliente) adicionar, visualizar, editar e excluir itens à sacola.|
|                         |RF-02 - A aplicação deve ser capaz de intermediar compras entre cliente e restaurante.|
|                         |RF-03 - A aplicação deve permitir ao usuário (cliente) escolher entre retirar o pedido no restaurante ou receber via delivery.|
|                         |RF-04 - A aplicação deve permitir ao usuário (cliente) realizar pagamentos sem sair do aplicativo.|
|                         |RF-05 - A aplicação deve oferecer ao usuário (cliente) as formas de pagamento presencial, no app ou na entrega.|
|Registro de evidência | [Pedidos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/tree/main/src/GourmetGo/Views/Pedidos) |

![pedidos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/blob/main/docs/img/pedido.png)

| **Caso de Teste** 	|**CT-04– Visualização do status do pedido** 	|
|:---:	|:---:	|
|**Requisitos Associados**|RF-01 - A aplicação deve ser capaz de informar ao usuário (cliente) o status do pedido (pedido recebido, pedido em preparação, pedido finalizado, pedido saiu para entrega).
|                         |RF-02 - A aplicação deve disponibilizar aos usuários (cliente e restaurante) o histórico completo de pedidos do cliente.
|Registro de evidência | [Pedidos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/tree/main/src/GourmetGo/Views/Pedidos) |

![status](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t3-gourmet-go/blob/main/docs/img/status.png)


## Avaliação

Data da Avaliação: [23/06/2024]
  Até o momento todas funcionalidades estão ativas e funcionando corretamente, como ponto forte temos uma aplicação bem fácil de usar pelo lado dos Usuários, com uma visualização de fácil entendimento e agradável de utilizar, como ponto fraco, é uma aplicação de pouca manutenibilidade, pois nao teve um padrào bem definido para criação de variáveis e etc.
  Pretendemos nos reunir e definir varios padrões de desenvolvimento, e aplica-lós no codigo atual, e para facilitar o entendimento vamos envolver mais comentários no mesmo.
  Através dos teste, melhoramos várias funcionalidades e fizemos um padrào mais agradavél ao usuário final, as falhas, que são poucas, serão corridas para a entrega final.

> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
