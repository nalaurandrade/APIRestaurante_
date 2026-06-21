# RestaurantOrderQueueApi

API REST desenvolvida em ASP.NET Core para gerenciamento de pedidos em restaurante utilizando fila de prioridade baseada em Heap.

## Objetivo

O sistema simula o atendimento de pedidos em um restaurante onde a ordem de preparo não depende apenas da ordem de chegada, mas também de critérios de prioridade definidos pela regra de negócio.

## Regra de Prioridade

A prioridade dos pedidos é calculada automaticamente utilizando os seguintes critérios:

| Critério | Pontuação |
|-----------|-----------|
| Cliente prioritário | +50 |
| Pedido Delivery | +30 |
| Tempo de preparo | +Tempo informado |

### Exemplo

Pedido A:

- Cliente prioritário: Sim
- Delivery: Sim
- Tempo de preparo: 20

Prioridade:

50 + 30 + 20 = 100

Pedido B:

- Cliente prioritário: Não
- Delivery: Sim
- Tempo de preparo: 15

Prioridade:

0 + 30 + 15 = 45

Neste caso o Pedido A será atendido primeiro.

### Critério de Desempate

Em caso de empate na prioridade, será atendido primeiro o pedido que foi cadastrado antes.

## Exclusão Lógica

A exclusão de pedidos não remove registros do banco de dados.

Ao executar o endpoint DELETE, o status do pedido é alterado para:

Cancelado

## Tecnologias Utilizadas

- ASP.NET Core
- C#
- Entity Framework Core
- PostgreSQL
- Docker
- Swagger

## Como Executar

### 1. Clonar o repositório

```bash
git clone https://github.com/seuusuario/RestaurantOrderQueueApi.git