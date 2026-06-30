# CleanArchitectureApp

A minimal .NET 8 Web API scaffold demonstrating **Clean Architecture** with a sample `Product` CRUD feature.

## Architecture

The solution is split into four projects, each with a single responsibility and a strict, one-directional dependency flow:

```
CleanArchitectureApp.API  -->  CleanArchitectureApp.Application  -->  CleanArchitectureApp.Domain
        |                                  ^
        '----> CleanArchitectureApp.Infrastructure --------'
```

- **Domain** has no dependencies on any other project. It contains only entities and core business types.
- **Application** depends only on Domain. It defines interfaces (repository and service contracts) and DTOs — the "ports" of the system.
- **Infrastructure** depends on Application (to implement its interfaces) and Domain. It contains EF Core, the `DbContext`, and repository implementations — the "adapters".
- **API** depends on Application and Infrastructure. It wires everything together via dependency injection and exposes HTTP endpoints.

This keeps business logic (Domain + Application) completely independent of frameworks, databases, and delivery mechanisms.

## Why Clean Architecture

- **Independence from frameworks and infrastructure** — the Domain and Application layers know nothing about EF Core, ASP.NET Core, or any specific database. They could be reused with a different web framework or persistence technology without modification.
- **Testability** — business logic in `Application` depends only on interfaces (`IProductRepository`, `IProductService`), so it can be unit tested with in-memory fakes or mocks, with no database or web server required.
- **Separation of concerns** — each layer has one job: Domain models the business, Application orchestrates use cases, Infrastructure handles technical details, API handles HTTP concerns. Changes in one layer (e.g., swapping EF Core for Dapper) don't ripple into the others.
- **Dependency Inversion** — high-level policy (Application) defines interfaces; low-level details (Infrastructure) implement them. Dependencies always point inward, toward the Domain, never outward.
- **Maintainability at scale** — as the codebase grows, this structure prevents the common "big ball of mud" problem where business logic, data access, and HTTP concerns become entangled.

## Folder Structure

```
CleanArchitectureApp/
├── CleanArchitectureApp.sln
└── src/
    ├── CleanArchitectureApp.Domain/
    │   ├── Common/
    │   │   └── BaseEntity.cs
    │   └── Entities/
    │       ├── Product.cs
    │       └── Order.cs
    │
    ├── CleanArchitectureApp.Application/
    │   ├── DTOs/
    │   │   └── ProductDto.cs
    │   ├── Interfaces/
    │   │   ├── IRepository.cs
    │   │   ├── IProductRepository.cs
    │   │   └── IProductService.cs
    │   ├── Services/
    │   │   └── ProductService.cs
    │   └── DependencyInjection.cs
    │
    ├── CleanArchitectureApp.Infrastructure/
    │   ├── Persistence/
    │   │   └── AppDbContext.cs
    │   ├── Repositories/
    │   │   ├── GenericRepository.cs
    │   │   └── ProductRepository.cs
    │   └── DependencyInjection.cs
    │
    └── CleanArchitectureApp.API/
        ├── Controllers/
        │   └── ProductsController.cs
        └── Program.cs
```

## Sample Feature: Product CRUD

The `Product` entity is exposed through `ProductsController` with the following endpoints:

| Method | Route                | Description          |
|--------|-----------------------|-----------------------|
| GET    | `/api/products`       | List all products     |
| GET    | `/api/products/{id}`  | Get a product by id    |
| POST   | `/api/products`       | Create a new product   |
| PUT    | `/api/products/{id}`  | Update an existing product |
| DELETE | `/api/products/{id}`  | Delete a product       |

The implementation follows SOLID principles:

- **Single Responsibility** — `ProductsController` only handles HTTP concerns; `ProductService` only orchestrates business logic; `ProductRepository` only handles data access.
- **Open/Closed** — new entities can reuse `GenericRepository<T>` without modifying it.
- **Liskov Substitution** — `ProductRepository` can be used anywhere `IProductRepository` (or `IRepository<Product>`) is expected.
- **Interface Segregation** — `IProductService` and `IProductRepository` expose only what each consumer needs.
- **Dependency Inversion** — the controller and service depend on abstractions (`IProductService`, `IProductRepository`), injected via the built-in ASP.NET Core DI container, not concrete implementations.

For simplicity, this scaffold uses EF Core's **InMemory** provider, so it runs out of the box with no external database required.

## Getting Started

```bash
# Restore and build
dotnet build

# Run the API (Swagger UI available in Development)
dotnet run --project src/CleanArchitectureApp.API
```
