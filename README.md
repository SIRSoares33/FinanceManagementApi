# 💸 Finance Management API

Uma API RESTful feita em ASP.NET Core para gerenciar finanças pessoais e organizacionais. Cada usuário pode criar diferentes *branches* (como "Casa", "Trabalho", "Investimentos"), que servem como agrupadores de receitas, despesas e outros dados financeiros.

---

## 📚 Tecnologias

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- JWT Authentication
- **Blazor WebAssembly (em desenvolvimento)** 🔥

---

## 📁 Funcionalidade Principal: Branch

Uma **Branch** representa uma área ou contexto financeiro. É vinculada a um usuário e pode ser usada para organizar transações, metas e relatórios.

---

## 🔐 Autenticação e autorização

- JWT Bearer Authentication
- Endpoints protegidos com `[Authorize]`

---

## 👤 Endpoints de usuário

- Cadastro e login
- Atualização de perfil
- Autorização por token

---

## 💰 Funcionalidades financeiras

- Criação e gerenciamento de **receitas e despesas**
- Organização por **categorias** e **branches**
- Lançamentos com validação de dados
- Futuro suporte a metas financeiras e gráficos

---

## 📊 Relatórios

- Relatórios por branch
- Visão mensal e anual
- Gráficos no front-end (com Blazor)

---

## 🖥️ Front-end com Blazor WebAssembly

O front-end será implementado com **Blazor WebAssembly** (em andamento). Ele será responsável por:

- Interface interativa com autenticação via JWT
- Dashboard com relatórios e gráficos
- Formulários para transações, filtros por data/categoria/branch
- Consumo direto da API com `HttpClient`

---

## 🧭 Como executar localmente

Clone o repositório:

```
git clone https://github.com/seu-usuario/FinanceManagementApi.git
cd FinanceManagementApi
```
Restaure os pacotes:
```
dotnet restore
```
Aplique as migrations (opcional, caso o banco esteja vazio):
```
dotnet ef database update
```
Execute a API:
```
dotnet run
```
Acesse a documentação Swagger:
```
https://localhost:{porta}/swagger
```
O Executando o Blazor:
```
cd ..
cd FinanceManagementBlazor
dotnet run
```

## 📄 Licença
Distribuído sob a licença MIT. Veja o arquivo LICENSE para mais informações.

## 🤝 Contribuindo
Pull requests são bem-vindos!
Para grandes mudanças, por favor, abra uma issue primeiro para discutirmos o que você gostaria de alterar.
