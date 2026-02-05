# SimpleWebApi.NetCore9

**Simple ASP.NET Core Web API** for managing Employee records with advanced features like pagination, sorting.

---

## **Table of Contents**
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Pagination & Sorting](#pagination--sorting)

---

## **Features**
- **Employee API**
  - CRUD operations connected to SQL Server via **EmployeeService**
  - Pagination and Sorting on GET endpoints
- **Department API**
  - CRUD operations using a **hardcoded repository**
  - Useful for testing or small datasets without a database


---

## **Tech Stack**
- ASP.NET Core 9 Web API  
- Entity Framework Core  
- SQL Server  

---
## Getting Started

### Clone the repository

bash

git clone https://github.com/FathimaMahamood/SimpleWebApi.NetCore9.git

cd SimpleWebApi.NetCore9

Open in Visual Studio

Open the .sln file.

Restore NuGet packages.

Update appsettings.json for your SQL Server connection.

Run the API
Press F5 or run the project via Visual Studio.


---
## **API Endpoints**

| Method  | URL                    | Description                   |
| ------- | ---------------------- | ----------------------------- |
| GET     | /api/employees         | Get all employees             |
| GET     | /api/employees/{id}    | Get employee by ID            |
| POST    | /api/employees         | Create new employee           |
| PUT     | /api/employees/{id}    | Full update of employee       |
| DELETE  | /api/employees/{id}    | Delete employee               |
| HEAD    | /api/employees/{id}    | Check if employee exists      |
| GET     | /api/Department        | Get all departments           |
| GET     | /api/Department/{id}   | Get departments by ID         |
| POST    | /api/Department        | Create new departments        |
| PUT     | /api/Department/{id}   | Full update of departments    |
| DELETE  | /api/Department/{id}   | Delete departments            |

---

## **Pagination & Sorting**

- GET supports query parameters:

  - page → page number

  - pageSize → number of items per page

  - sortBy → Id, Name, Gender, Department

  - orderBy → asc / desc

- Response includes headers:

  - X-Total-Count → total number of records

