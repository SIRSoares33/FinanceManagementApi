# 💰 Projeto de Gestão Financeira

Sistema de **gestão financeira pessoal** desenvolvido com **Blazor WebAssembly** no frontend e **ASP.NET Core Web API** no backend. O sistema permite o controle de **transações financeiras**, organização por **categorias** e **branches** (subcontas ou carteiras).

## 📌 Funcionalidades

- ✅ Cadastro e autenticação de usuários 
- 💳 Registro de **transações** (entradas e saídas)
- 🌿 Suporte a múltiplas **branches** (ex: Carteira, Conta Corrente, Poupança)
- 🔄 Integração total entre o frontend (Blazor) e backend (API REST)

## 🛠️ Tecnologias Utilizadas

### Backend (API)

- ASP.NET Core
- Entity Framework Core
- AutoMapper
- SQLite

### Frontend (Blazor WebAssembly)

- Blazor WASM
- Bootstrap
- HttpClient para consumo da API
- LocalStorage (para token JWT)

## 🚀 Como Rodar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/)
- Visual Studio ou VS Code
- (Opcional) SQLite

### Passo a passo

1. Clone o repositório:
    
    ```
    git clone https://github.com/seu-usuario/FinanceManagementApi.git
    ```
    
2. Execute as migrações do banco de dados:
    
    ```
    cd FinanceManagementApi
    dotnet ef database update
    ```
    
3. Inicie a API:
    
    ```
    dotnet run
    ```
    
4. Execute o projeto Blazor:
    
    ```
    cd ../FinanceManagementBlazor
    dotnet run
    ```
    
5. Acesse no navegador:
    
    ```
    https://localhost:5001 (Exemplo de rota do wasm)
    ```
    
## 📦 Futuras Implementações

- 📱 Versão mobile com .NET MAUI
- 📈 Gráficos de desempenho financeiro
- ☁️ Deploy na nuvem (Azure, Vercel, etc.)

## 🤝 Contribuição

Sinta-se à vontade para contribuir! Fork o projeto, crie uma branch e envie um Pull Request.

## 📄 Licença

Este projeto está licenciado sob a MIT License.
