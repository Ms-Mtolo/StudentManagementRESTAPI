# StudentManagementRESTAPI

A RESTful Web API built with **ASP.NET Core (.NET 10)** for managing student records. It provides full CRUD (Create, Read, Update, Delete) operations over an in-memory list of students, and includes Swagger/OpenAPI documentation for easy testing.

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [API Endpoints](#-api-endpoints)
  - [Students](#students)
  - [Weather Forecast (Sample)](#weather-forecast-sample)
- [Data Model](#-data-model)
- [Swagger / OpenAPI](#-swagger--openapi)
- [Configuration](#-configuration)
- [Testing with the .http File](#-testing-with-the-http-file)
- [Future Improvements](#-future-improvements)
- [License](#-license)

---

## 📖 Overview

**StudentManagementRESTAPI** is a lightweight ASP.NET Core Web API that demonstrates how to build a RESTful service for managing student data. Student records are stored **in memory** (a static `List<Student>`), making it ideal for learning, prototyping, or as a starting point for a database-backed application.

The project targets **.NET 10** and uses **Swashbuckle.AspNetCore** to generate interactive Swagger UI documentation.

---

## ✨ Features

- ✅ Full CRUD operations for students (GET, POST, PUT, DELETE)
- ✅ In-memory data store (no database required to run)
- ✅ Swagger UI for interactive API testing
- ✅ OpenAPI 3.0 specification generation
- ✅ Built-in sample `WeatherForecast` controller
- ✅ HTTPS redirection enabled
- ✅ Environment-based configuration (`appsettings.json` / `appsettings.Development.json`)

---

## 🛠 Tech Stack

| Technology | Version |
|---|---|
| .NET | 10.0 |
| ASP.NET Core | 10.0 |
| Swashbuckle.AspNetCore.SwaggerGen | 10.2.3 |
| Swashbuckle.AspNetCore.SwaggerUI | 10.2.3 |
| Microsoft.AspNetCore.OpenApi | 10.0.11 |

---

## 📁 Project Structure

```
StudentManagementRESTAPI/
│
├── Controllers/
│   ├── StudentsController.cs        # CRUD endpoints for students
│   └── WeatherForecastController.cs # Sample controller
│
├── Models/
│   └── Student.cs                   # Student data model
│
├── Properties/
│   └── launchSettings.json          # Launch profiles (http/https)
│
├── Program.cs                       # Application entry point & middleware pipeline
├── StudentManagementRESTAPI.csproj  # Project file (dependencies & target framework)
├── appsettings.json                 # Global configuration
├── appsettings.Development.json     # Development-specific configuration
├── StudentManagementRESTAPI.http    # HTTP request samples for testing
└── README.md                        # This file
```

---



## 🔌 API Endpoints

Base route: `/api/students`

### Students

| Method | Endpoint | Description | Request Body | Response |
|---|---|---|---|---|
| `GET` | `/api/students` | Get all students | — | `200 OK` — Array of students |
| `GET` | `/api/students/{id}` | Get a student by ID | — | `200 OK` — Student / `404 Not Found` |
| `POST` | `/api/students` | Create a new student | `Student` (JSON) | `201 Created` — Created student |
| `PUT` | `/api/students/{id}` | Update an existing student | `Student` (JSON) | `200 OK` — Updated student / `404 Not Found` |
| `DELETE` | `/api/students/{id}` | Delete a student | — | `204 No Content` / `404 Not Found` |

#### Example — Get all students

```http
GET http://localhost:5032/api/students
Accept: application/json
```

**Response:**

```json
[
  { "id": 1, "name": "John", "email": "john@example.com", "surname": "", "course": "", "year": 0, "studentNumber": "" },
  { "id": 2, "name": "Mary", "email": "mary@example.com", "surname": "", "course": "", "year": 0, "studentNumber": "" }
]
```

#### Example — Create a student

```http
POST http://localhost:5032/api/students
Content-Type: application/json

{
  "name": "Alice",
  "surname": "Smith",
  "email": "alice@example.com",
  "course": "Computer Science",
  "year": 2,
  "studentNumber": "STU003"
}
```

**Response:** `201 Created`

```json
{
  "id": 3,
  "name": "Alice",
  "surname": "Smith",
  "email": "alice@example.com",
  "course": "Computer Science",
  "year": 2,
  "studentNumber": "STU003"
}
```

#### Example — Update a student

```http
PUT http://localhost:5032/api/students/1
Content-Type: application/json

{
  "name": "Johnathan",
  "email": "johnathan@example.com"
}
```

#### Example — Delete a student

```http
DELETE http://localhost:5032/api/students/2
```

**Response:** `204 No Content`

---

### Weather Forecast (Sample)

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/WeatherForecast` | Returns a 5-day random weather forecast |

This is the default template controller and can be safely removed if not needed.

---

## 🧱 Data Model

### `Student`

Located in `Models/Student.cs`:

```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Course { get; set; } = string.Empty;
    public int Year { get; set; }
    public string StudentNumber { get; set; } = string.Empty;
}
```

| Property | Type | Description |
|---|---|---|
| `Id` | `int` | Unique identifier (auto-assigned) |
| `Name` | `string` | Student's first name |
| `Surname` | `string` | Student's last name |
| `Email` | `string` | Student's email address |
| `Course` | `string` | Enrolled course |
| `Year` | `int` | Year of study |
| `StudentNumber` | `string` | Institution-issued student number |

---

## 📘 Swagger / OpenAPI

Swagger is enabled **only in the Development environment**.

Once the app is running, navigate to:

```
https://localhost:7074/swagger
```

or

```
http://localhost:5032/swagger
```

The raw OpenAPI specification is available at:

```
/swagger/v1/swagger.json
```

---

## ⚙️ Configuration

### `appsettings.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### `appsettings.Development.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### `launchSettings.json`

Defines two profiles:

- **http** → `http://localhost:5032`
- **https** → `https://localhost:7074;http://localhost:5032`

Set `ASPNETCORE_ENVIRONMENT` to `Development` to enable Swagger.

---

## 🧪 Testing with the .http File

The project includes a `StudentManagementRESTAPI.http` file for quick testing in Visual Studio or VS Code (with the REST Client extension).

```http
@StudentManagementRESTAPI_HostAddress = http://localhost:5032

GET {{StudentManagementRESTAPI_HostAddress}}/weatherforecast/
Accept: application/json

###
```

Add your own requests:

```http
GET {{StudentManagementRESTAPI_HostAddress}}/api/students
Accept: application/json

###

POST {{StudentManagementRESTAPI_HostAddress}}/api/students
Content-Type: application/json

{
  "name": "Alice",
  "surname": "Smith",
  "email": "alice@example.com",
  "course": "Computer Science",
  "year": 2,
  "studentNumber": "STU003"
}
```

---



