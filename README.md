# 🍽️ RestaurantOrderQueueApi

API REST desenvolvida em **.NET 10** para gerenciamento de pedidos em fila de restaurante, com controle de prioridade, status, paginação e exclusão lógica.

---

## 📌 Objetivo

O sistema tem como objetivo simular uma fila de pedidos de restaurante, permitindo:

- Cadastro de pedidos
- Consulta por ID
- Listagem paginada
- Busca por descrição
- Atualização de pedidos
- Cancelamento lógico (não remove do banco)

---

## 🧱 Arquitetura

O projeto segue princípios de **Clean Architecture**, dividido em camadas:

RestaurantOrderQueueApi
│
├── Api (Controllers e DTOs)
├── Application (Services, UseCases, Interfaces)
├── Domain (Entities, Enums, Interfaces)
├── Infrastructure (Banco de dados e Repositórios)


---

## ⚙️ Tecnologias Utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- Swagger (OpenAPI)
- C#

---

## 📦 Funcionalidades

### ✔ Criar pedido
Cria um novo pedido com status inicial `Pendente`.

### ✔ Listar pedidos
Lista todos os pedidos cadastrados.

### ✔ Listagem paginada
Permite paginação:


GET /recurso?page=1&size=10


### ✔ Buscar por ID
Retorna um pedido específico.


GET /recurso/{id}

### ✔ Buscar por filtro
Busca pedidos por descrição:


GET /recurso/buscar?descricao=burger


### ✔ Atualizar pedido
Atualiza dados e recalcula prioridade/valor.


PUT /recurso/{id}


### ✔ Cancelar pedido (exclusão lógica)
Altera status para `Cancelado`.


DELETE /recurso/{id}


---

## 🔗 Endpoints da API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| POST | `/recurso` | Criar pedido |
| GET | `/recurso/{id}` | Buscar por ID |
| GET | `/recurso` | Listar paginado |
| GET | `/recurso/buscar` | Buscar por descrição |
| PUT | `/recurso/{id}` | Atualizar pedido |
| DELETE | `/recurso/{id}` | Cancelar pedido |

---

## ▶️ Como executar o projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/nalaurandrade/APIRestaurante_.git

2. Entrar na pasta do projeto
cd APIRestaurante
3. Restaurar dependências
dotnet restore
4. Rodar a API
dotnet run --project RestaurantOrderQueueApi.Api

🌐 Swagger

Após rodar o projeto:

http://localhost:5227
📁 Estrutura do Pedido
{
  "clienteNome": "João Silva",
  "descricao": "Hambúrguer com batata",
  "clientePrioritario": true,
  "delivery": false,
  "tempoPreparo": 15,
  "prioridade": 1
}
📊 Regras de Negócio
Todo pedido inicia com status Pendente
O valor é calculado automaticamente
Exclusão é lógica (status = Cancelado)
Paginação baseada em page e size
👨‍💻 Autor

Projeto desenvolvido para fins acadêmicos.

