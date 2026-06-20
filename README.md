# 🛠️ Skill Management System

[![Framework](https://img.shields.io/badge/.NET-10.0-blueviolet?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![Database](https://img.shields.io/badge/SQL_Server-2022-red?style=flat-square&logo=microsoft-sql-server)](https://www.microsoft.com/en-us/sql-server/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%20%2F%20DDD-success?style=flat-square)]()
[![Code Style](https://img.shields.io/badge/code%20style-.editorconfig-informational?style=flat-square)]()

An enterprise-ready **Skill Management System** built with **C#** and **.NET 10**. This application acts as a centralized governance registry designed to audit, evaluate, and trace developer technical competencies, manage resource allocation metrics across internal projects, and track technical growth curves over time.

---

## 🏗️ Architectural Blueprint

The codebase relies on strict **Domain-Driven Design (DDD)** and **Clean Architecture** patterns to keep core business rules completely independent of UI frameworks, API route layouts, and database drivers.

```text
├── 📂 SkillManagement.CoreBusiness    # Pure Domain Entities, Aggregates, Value Objects
├── 📂 SkillManagement.UseCases        # Interactors, Core Business Orchestration, Validation Logic
├── 📂 SkillManagement.Plugins         # EF Core Data Context, Migrations, Repository Adapters
└── 📂 SkillManagement.API / WebApp    # Presentation Layer & External Entry Points
