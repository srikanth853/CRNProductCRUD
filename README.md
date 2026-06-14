# CRN Product CRUD API

RESTful backend API for Product CRUD operations using ASP.NET Core Web API.

## Tech Stack

- .NET 8 / ASP.NET Core Web API
- SQL Server / LocalDB
- Entity Framework Core
- JWT Authentication
- FluentValidation
- Swagger/OpenAPI
- xUnit
- Docker

## Architecture

- API
- Application
- Domain
- Infrastructure
- Tests

## API Endpoints

### Auth

POST /api/v1/auth/login

### Products

GET /api/v1/products  
GET /api/v1/products/{id}  
POST /api/v1/products  
PUT /api/v1/products/{id}  
DELETE /api/v1/products/{id}

## Login

```json
{
  "userName": "admin",
  "password": "Admin@123"
}