# 🏆 My Championship

## 📌 Sobre o Projeto

**My Championship** é uma aplicação **ASP.NET Core** desenvolvida para **cadastro de campeonatos**, **gerenciamento de times** e **geração de chaves** de forma simples e organizada.

O projeto segue boas práticas de arquitetura, separando claramente as responsabilidades entre **API**, **Application**, **Domain** e **Infrastructure**, além de utilizar **Docker** para facilitar o setup e a execução do ambiente.

---

## 📦 Bibliotecas Utilizadas

- **FluentValidation.AspNetCore**
  Biblioteca utilizada para validação de dados de entrada (DTOs), garantindo regras claras e centralizadas.

- **Entity Framework Core**
  ORM utilizado para acesso e persistência de dados.

- **Npgsql**
  Provider do PostgreSQL para .NET.

---

## ⚙️ Pré-requisitos

Antes de iniciar, certifique-se de ter instalado:

- Docker
- Docker Compose

---

## ▶️ Como Executar a Aplicação

### 1️⃣ Clonar o repositório

```bash
git clone <URL_DO_REPOSITORIO>
cd my-championship
```

### 2️⃣ Subir a aplicação com Docker Compose

```bash
docker compose up --build
```

### 3️⃣ Acessar a aplicação

- **HTTP**: [http://localhost:5000](http://localhost:5000)
- **HTTPS**: [https://localhost:5001](https://localhost:5001) _(caso esteja configurado)_

### 4️⃣ Parar a aplicação

```bash
docker compose down
```

---

## 🧪 Documentação da API (Swagger)

Em ambiente de desenvolvimento, a API expõe o **Swagger UI**, onde é possível visualizar e testar os endpoints.

Acesse em:

```
http://localhost:5000/swagger
```

---

## 🗂️ Estrutura do Projeto

```text
my_championship
├── Api/              # Controllers, Presenters e camada de apresentação
├── Application/      # Casos de uso, DTOs e validações
├── Domain/           # Entidades e regras de negócio
├── Infrastructure/   # Banco de dados, repositórios e configurações
```

---

## 🗄️ Migrations (Entity Framework)

### Criar uma nova migration

```bash
dotnet ef migrations add <NomeDaMigration>
```

Exemplo:

```bash
dotnet ef migrations add CreateChampionshipTables
```

### Aplicar migrations no banco

```bash
dotnet ef database update
```

---

## 🔧 Configuração do dotnet-ef

Caso ainda não tenha o `dotnet-ef` instalado:

```bash
dotnet tool install --global dotnet-ef
```

Se estiver usando Linux ou containers, garanta que o caminho esteja no `PATH`:

```bash
export PATH="$PATH:/root/.dotnet/tools"
```

---

## 🛠️ Solução de Problemas

### 🔒 Erros com HTTPS / Certificado

Se ocorrerem erros relacionados a HTTPS, você pode:

- Desabilitar HTTPS no ambiente de desenvolvimento (`Program.cs`)
- Gerar e configurar um certificado HTTPS válido no container

---

### 📄 Ver logs do container

```bash
docker logs my_championship_dotnet_app
```

---

### 🖥️ Acessar o terminal do container

```bash
docker exec -it my_championship_dotnet_app sh
```

---

## 📜 Licença

Este projeto está licenciado sob a **Licença MIT**.
Consulte o arquivo `LICENSE` para mais detalhes.

---
