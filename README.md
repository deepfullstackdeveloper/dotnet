# Blog API

A simple .NET 8 Web API project to perform CRUD (Create, Read, Update, Delete) operations on a blog resource. This API is designed to demonstrate basic RESTful endpoints using `BlogController`.

---

## Features

- **Create a Blog**: Add new blog entries.
- **Retrieve Blogs**: Get a list of all blogs or fetch a specific blog by ID.
- **Update a Blog**: Edit existing blog entries.
- **Delete a Blog**: Remove a blog by ID.

---

## Endpoints

| HTTP Method | Endpoint          | Description              |
|-------------|-------------------|--------------------------|
| GET         | `/api/blog`      | Retrieve all blogs       |
| GET         | `/api/blog/{id}` | Retrieve a blog by ID    |
| POST        | `/api/blog`      | Create a new blog        |
| PUT         | `/api/blog/{id}` | Update an existing blog  |
| DELETE      | `/api/blog/{id}` | Delete a blog by ID      |

---

## Prerequisites

1. **.NET 8 SDK**: Ensure you have the .NET 8 SDK installed. You can download it from [Microsoft's official site](https://dotnet.microsoft.com/download).
2. **Database Setup**: The project uses an in-memory database for simplicity. For production, configure a real database in `appsettings.json`.

---

## Run the Project

### Steps to Run:

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   cd <repository-folder>
2. **Restore dependencies:**
    ```bash
    dotnet restore
3. **Build the project:**
    ```bash
    dotnet build
4. **Run the API:**
    ```bash
    dotnet run
