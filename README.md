# 💸 Finance Management API

Uma API RESTful feita em **ASP.NET Core** para gerenciar finanças pessoais e organizacionais. Cada usuário pode criar diferentes **branches** (como "Casa", "Trabalho", "Investimentos"), que servem como agrupadores de receitas, despesas e outros dados financeiros.

---

## 📚 Tecnologias

- [.NET 9](https://dotnet.microsoft.com/en-us/)
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- JWT Authentication

---

## 📁 Funcionalidade Principal: Branch

Uma **Branch** representa uma área ou contexto financeiro. É vinculada a um usuário e pode ser usada para organizar transações, metas e relatórios.
--- 
- 🔐 Autenticação e autorização via JWT

- 👤 Endpoints de usuário (cadastro, login)

- 💰 Entidades financeiras (receitas, despesas, categorias)

- 📊 Relatórios por branch

---

## 🧭 Como executar localmente
Clone o repositório:
``` bash
git clone https://github.com/seu-usuario/FinanceManagementApi.git
```
Restaure os pacotes: 
``` bash
dotnet restore
```

Aplique as migrations (opcional, caso o banco esteja vazio):

```bash
dotnet ef database update
```

Execute a API:

``` bash
dotnet run
```
Acesse a documentação Swagger:

```bash
https://localhost:{porta}/swagger
```

## 📄 Licença
Distribuído sob a licença MIT. Veja LICENSE para mais informações.

## 🤝 Contribuindo
Pull requests são bem-vindos. Para grandes mudanças, por favor abra uma issue primeiro para discutir o que você gostaria de alterar.

