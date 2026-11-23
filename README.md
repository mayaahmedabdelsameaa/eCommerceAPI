# eCommerce API

**ASP.NET Core Web API | C# | Entity Framework Core | SQL Server**

## Overview

A backend API project for managing and retrieving e-commerce product catalog data.

The project focuses on building structured RESTful APIs using a layered architecture, Entity Framework Core, and reusable data access components.

It demonstrates practical backend development concepts, including the Repository and Specification patterns, product filtering, sorting, pagination, and centralized exception handling.

## Tech Stack

- **Framework:** ASP.NET Core Web API (.NET 6)
- **Language:** C#
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Object Mapping:** AutoMapper
- **API Documentation:** Swagger / OpenAPI

## Architecture

The solution is organized into three main projects:

**Core**
- Domain entities and relationships
- Repository interfaces
- Specification definitions

**Infrastructure**
- Repository implementations
- Entity Framework Core DbContext
- Database migrations and seed data
- Specification evaluation

**eCommerceAPI**
- RESTful API controllers
- Data Transfer Objects (DTOs)
- AutoMapper configuration
- Exception-handling middleware
- Application configuration

## Features

- Product catalog retrieval
- Product details with brand and type information
- Filtering by product brand and type
- Product name search
- Price-based sorting
- Paginated product responses
- Repository and Specification patterns
- Centralized API exception handling
- Database migrations and initial data seeding

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Product` | Retrieve products with filtering, sorting and pagination |
| GET | `/api/Product/brands` | Retrieve product brands |
| GET | `/api/Product/types` | Retrieve product types |

A product-by-ID action is also implemented, but its route requires correction before documenting it as a stable endpoint.

## Getting Started

**Prerequisites**

- .NET 6 SDK
- SQL Server
- Git

**Local setup**

1. Clone the repository.
2. Restore the .NET dependencies.
3. Configure the SQL Server connection string using the `ConnectionStrings:DB` setting.
4. Review and apply the included EF Core migrations.
5. Run the Web API project.
6. Use Swagger to explore the available endpoints in the Development environment.

The database initialization and startup flow still require verification before these steps can be considered fully tested.

## Project Status

This is an earlier backend portfolio project showcasing foundational ASP.NET Core development concepts.

The repository is being reviewed for documentation improvements, correctness fixes, and dependency updates before being presented as a polished portfolio project.

## Author

**Mayar Ahmed** — Backend Software Engineer

[GitHub](https://github.com/mayaahmedabdelsameaa) | [LinkedIn](https://www.linkedin.com/in/mayar-ahmed-abdelsameaa/)
