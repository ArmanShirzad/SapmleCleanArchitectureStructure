# Sample Clean Architecture Structure

A .NET solution demonstrating the principles of Clean Architecture, best practices, and modular design for scalable, maintainable enterprise applications.

---

## 📝 Table of Contents

* [About](#about)
* [Architecture Overview](#architecture-overview)
* [Features](#features)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Clone & Build](#clone--build)
* [Project Structure](#project-structure)
* [Running Tests](#running-tests)
* [Contributing](#contributing)
* [License](#license)

---

## About

This repository provides a lightweight **Clean Architecture** template implemented in C#/.NET. It separates concerns into explicit layers—Domain, Application, Infrastructure, and Presentation—so that each layer has a single responsibility and clear dependencies. Use it as a starting point for your next enterprise-grade project.

## Architecture Overview

```
┌─────────────────────────────────────────────────────┐
│ Presentation (API, UI, CLI)                        │
│  └─ Depends on Application                          │
│                                                     │
│ Application (Use Cases, DTOs, Interfaces)          │
│  └─ Depends on Domain                               │
│                                                     │
│ Domain (Entities, Value Objects, Domain Services)  │
│  └─ No external dependencies                        │
│                                                     │
│ Infrastructure (Data, Logging, External Services)  │
│  └─ Depends on Application & Domain                 │
└─────────────────────────────────────────────────────┘
```

* **Presentation**: Entry point—could be ASP.NET Core Web API, Blazor, or a Console app.  
* **Application**: Use-case layer orchestrating workflows and defining interfaces.  
* **Domain**: Core business models, rules, and policies (no external dependencies).  
* **Infrastructure**: Data persistence (EF Core), external integrations, logging, etc.

## Features

* ✅ **Layered project**: Enforces strict boundaries with only inward dependencies.  
* ✅ **Dependency Injection**: All services and repositories are injected via interfaces.  
* ✅ **Entity Framework Core**: Sample persistence implementation in Infrastructure layer.  
* ✅ **Unit Testing**: Example tests for Infrastructure.Persistence using xUnit.  
* ✅ **Modular & Scalable**: Easily swap out implementations or add new layers.

## Getting Started

### Prerequisites

* [.NET SDK 7.0+](https://dotnet.microsoft.com/download)  
* IDE of your choice (Visual Studio 2022, Rider, VS Code + C# extension)

### Clone & Build

```bash
# Clone the repo
git clone https://github.com/ArmanShirzad/SapmleCleanArchitectureStructure.git
cd SapmleCleanArchitectureStructure

# Restore dependencies & build
dotnet restore
dotnet build
```

## Project Structure

```
SapmleCleanArchitectureStructure.sln
├── src/
│   ├── Presentation/      # Entry-point project (Web API, UI, etc.)
│   ├── Application/       # Use-cases, DTOs, interfaces
│   ├── Domain/            # Entities, value objects, domain logic
│   └── Infrastructure/    # EF Core, external services, persistence
└── tests/
    └── UnitTests/
        └── Infrastructure.Persistence/  # Example xUnit tests
```

> Each folder under `src/` is a separate .NET project, referenced in the solution.

## Running Tests

```bash
# From solution root
dotnet test
```

This will run all unit tests under the `tests/UnitTests` folder.

## Contributing

1. Fork the repository  
2. Create your feature branch (`git checkout -b feature/YourFeature`)  
3. Commit your changes (`git commit -m 'Add new feature'`)  
4. Push to the branch (`git push origin feature/YourFeature`)  
5. Open a Pull Request  

Please make sure your code follows the existing style and include unit tests for any new functionality.

## License

This project is licensed under the MIT License. See [LICENSE.txt](LICENSE.txt) for details.

---

Happy coding! 🚀
