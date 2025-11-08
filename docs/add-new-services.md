# Como adicionar um novo serviço à solução

## Estrutura padrão
Cada serviço deve seguir Clean Architecture + Hexagonal (Ports & Adapters):
- **Domain**: Entidades, Aggregates, Value Objects, Domain Services, Domain Events
- **Application**: Casos de uso, Commands/Queries, orquestração
- **Ports**: Interfaces de saída (repositórios, mensageria, storage, hashing, assinatura)
- **Adapters**: Implementações (EF Core/Dapper, RabbitMQ, Azure Blob, JWS, etc.)
- **API**: Minimal APIs ou Controllers – dependem de Application, nunca de infra

---

## Passos para criar um novo serviço

### 1. Criar projetos
```bash
cd src/Services/NomeDoServico

dotnet new classlib -n NomeDoServico.Domain
dotnet new classlib -n NomeDoServico.Application
dotnet new classlib -n NomeDoServico.Ports
dotnet new classlib -n NomeDoServico.Adapters
dotnet new webapi -n NomeDoServico.API

```
### Adicionando Referências
```
cd src/Services/NomeDoServico/NomeDoServico.Application
dotnet add reference ../NomeDoServico.Domain/NomeDoServico.Domain.csproj
dotnet add reference ../NomeDoServico.Ports/NomeDoServico.Ports.csproj

cd ../NomeDoServico.API
dotnet add reference ../NomeDoServico.Application/NomeDoServico.Application.csproj
dotnet add reference ../NomeDoServico.Adapters/NomeDoServico.Adapters.csproj

cd ../NomeDoServico.Adapters
dotnet add reference ../NomeDoServico.Ports/NomeDoServico.Ports.csproj
```

### Adicionar os projetos à solution
```
cd raiz-do-repositorio

dotnet sln add src/Services/NomeDoServico/NomeDoServico.Domain/NomeDoServico.Domain.csproj
dotnet sln add src/Services/NomeDoServico/NomeDoServico.Application/NomeDoServico.Application.csproj
dotnet sln add src/Services/NomeDoServico/NomeDoServico.Ports/NomeDoServico.Ports.csproj
dotnet sln add src/Services/NomeDoServico/NomeDoServico.Adapters/NomeDoServico.Adapters.csproj
dotnet sln add src/Services/NomeDoServico/NomeDoServico.API/NomeDoServico.API.csproj
```
### Instalar pacotes comuns

#### Application:
```
dotnet add package MediatR
dotnet add package FluentValidation
dotnet add package Mapster
```
#### API:
```
dotnet add package Swashbuckle.AspNetCore
```
#### Adapters:
```
dotnet add package Polly
dotnet add package MassTransit
```
#### Shared.Infrastructure:
```
dotnet add package Serilog
dotnet add package OpenTelemetry.Extensions.Hosting
```

