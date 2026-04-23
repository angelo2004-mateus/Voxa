# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Git Policy

**Never commit automatically.** Only create commits when the user explicitly requests it with a clear instruction like "commit", "faça um commit", or "cria um commit". Completing a task does NOT imply permission to commit. When in doubt, do not commit — ask first.

## Commands

```bash
# Build
dotnet build

# Run API (development)
dotnet run --project Voxa.Backoffice.Api

# EF Core migrations (run from repo root)
dotnet ef migrations add <MigrationName> --project Voxa.Infrastructure --startup-project Voxa.Backoffice.Api
dotnet ef database update --project Voxa.Infrastructure --startup-project Voxa.Backoffice.Api
```

Ports: HTTP `5116`, HTTPS `7006`
Database: PostgreSQL at `localhost:5432`, database `voxa`, user `postgres`, password `postgres`

## Architecture

This is a **.NET 9 ASP.NET Core API** following **Clean Architecture** with a solution (`Voxa.sln`) organized into three layers:

### Solution Layers

**APIs** — Entry point
- `Voxa.Backoffice.Api` — Controllers, Program.cs, DI setup

**Core** — Business logic (no framework dependencies)
- `Voxa.Domain` — Aggregate roots, entities, enums
- `Voxa.Application` — DTOs and application service contracts
- `Voxa.Infrastructure` — EF Core `AppDbContext`, entity configurations, migrations

**Framework** — Reusable base abstractions (not domain-specific)
- `Framework.Domain` — `Entity<TId>`, `AuditedAggregate<TId>`, auditing interfaces
- `Framework.Application` — `IApplicationService`, `IPasswordService`
- `Framework.Infrastructure` — `BaseDbContext`, `EntityTypeConfig<T>`, `AuditedAggregateTypeConfiguration<T>`, `PasswordService` (BCrypt)

### Domain Model

```
User (AuditedAggregate<Guid>)
  └── Name, Email, Password (hashed), Role (UserRole enum)

Organization (AuditedAggregate<Guid>)
  └── Name

OrganizationMembership (Entity<Guid>)
  └── UserId → User, OrganizationId → Organization, Role (OrganizationRole enum)
```

User ↔ Organization is a many-to-many via `OrganizationMembership`. Memberships cascade-delete when either parent is deleted.

### Key Conventions

- **Table/column naming**: All names are auto-lowercased via `NamingConvention` in `BaseDbContext`.
- **IDs**: `Guid` PKs generated at DB level using `gen_random_uuid()`.
- **Auditing**: Aggregates inheriting `AuditedAggregate<TId>` automatically get `CreationTime` and `UpdatedTime`.
- **Entity configurations**: Each entity has a dedicated `IEntityTypeConfiguration<T>` in `Voxa.Infrastructure/Data/Persistence/Configurations/`. Extend `AuditedAggregateTypeConfiguration<T>` for aggregates.
- **Password hashing**: Use `IPasswordService` (BCrypt implementation in `Framework.Infrastructure`) — not raw BCrypt calls.
- **Auth**: Custom `User` entity (ASP.NET Core Identity tables were removed in migration `RemoveIdentity`).

### Naming & File Conventions

- **DTOs**: Always **classes** (never `record` or `record class`). Located in `Models/<Context>/` inside the Application layer.
- **File prefix rule**: Every file must be prefixed with its immediate parent folder name. Examples:
  - `Models/Auth/AuthLoginRequest.cs` → class `AuthLoginRequest`
  - `Models/Auth/AuthTokenResponse.cs` → class `AuthTokenResponse`
  - `Models/Users/UserDto.cs` → class `UserDto`
  - `Controllers/Auth/AuthController.cs` → class `AuthController`
  - `Services/Auth/AuthService.cs` → class `AuthService`
  - This rule applies to all files: DTOs, services, interfaces, configurations, etc.
- **Interfaces in Application layer**: Placed in `Contracts/<Context>/` and also prefixed by folder. Example: `Contracts/Auth/IAuthJwtService.cs`.
- **No inline property defaults**: Never assign default values directly on properties (e.g., no `string Name { get; set; } = string.Empty`). Properties with no value must have no initializer (`string Name { get; set; }`). Any non-null default must be assigned in a parameterless constructor.
- **No `?` on strings**: Use `string` (not `string?`) — strings are reference types and nullable by nature. Same applies to other reference types unless a specific nullability contract is required.
- **All public/protected members must be `virtual`**: Every public or protected property and method in Framework and Voxa classes must be declared `virtual`. This is required for NHibernate proxy support in future integrations.
- **Multi-tenancy**: Entities scoped to a tenant implement `IMultiTenant` (`Framework.Domain.Entities.Interfaces`), which exposes `Guid? TenantId`.