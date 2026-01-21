# My Championship

## Bibliotecas Instaladas

- **FluentValidation.AspNetCore**: Biblioteca para validação de modelos no ASP.NET Core.

## Sobre o Projeto

My Championship é uma aplicação ASP.NET Core para gerenciar campeonatos. Este projeto utiliza Docker para facilitar a execução e o desenvolvimento.

## Pré-requisitos

- Docker instalado na máquina.
- Docker Compose instalado.

## Como executar a aplicação

1. Clone este repositório:

    ```bash
    git clone <URL_DO_REPOSITORIO>
    cd my-championchip
    ```

2. Construa e inicie os containers com Docker Compose:

    ```bash
    docker compose up --build
    ```

3. Acesse a aplicação no navegador:
    - HTTP: [http://localhost:5000](http://localhost:5000)
    - HTTPS: [https://localhost:5001](https://localhost:5001) (se configurado corretamente)

4. Para parar os containers:
    ```bash
    docker compose down
    ```

## Solução de Problemas

### Certificado HTTPS

Se encontrar erros relacionados ao certificado HTTPS, você pode:

- Desabilitar HTTPS no ambiente de desenvolvimento (veja `Program.cs`).
- Gerar um certificado HTTPS válido e montá-lo no container.

### Logs do Container

Para verificar os logs do container:

```bash
docker logs my_championship_dotnet_app
```

### Acessar o Container

Para acessar o terminal do container:

```bash
docker exec -it my_championship_dotnet_app sh
```

## Estrutura do Projeto

- **Api/**: Contém os controladores da API.
- **Application/**: Contém os casos de uso e interfaces.
- **Domain/**: Contém as entidades do domínio.
- **Infrastructure/**: Contém a configuração do banco de dados e outras implementações.

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.
