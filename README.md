# VerificationProvider — .NET 8 Azure Functions

An educational verification service built during my full-stack studies at EC Utbildning.

## Implementation

- .NET 8 isolated-worker Azure Functions (v4).
- Service Bus-triggered verification-code generation.
- HTTP verification validation: `POST /api/validate` with function-level authorization.
- Timer-triggered verification cleanup.
- Entity Framework Core data context and migrations.

The repository contains Functions and services, rather than an ASP.NET MVC controller application.

## Structure

- `VerificationProvider/Functions/`: generation, validation, and cleanup entry points.
- `VerificationProvider/Services/`: verification and cleanup logic.
- `VerificationProvider/Data/Context/`: database context.
- `VerificationProvider/Migrations/`: EF Core migrations.
- `VerificationProvider/host.json`: Functions host configuration.

## Local development

Install the .NET 8 SDK and Azure Functions Core Tools. Configure the database, Service Bus, and local Functions settings for your environment before starting.

```bash
git clone https://github.com/Norman-Deen/VerificationProvider.git
cd VerificationProvider
dotnet restore VerificationProvider.sln
cd VerificationProvider
func start
```

Use the endpoints printed by Functions Core Tools. Deployment settings and cloud resources are environment-specific; old resource names do not guarantee an active public service.

## Scope

Coursework retained to demonstrate backend integration, messaging, validation, and scheduled processing.

[Nour Altinawi — Nourtin](https://nourtin.com/) · [Current real-time 3D work](https://github.com/Norman-Deen)
