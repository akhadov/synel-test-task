# Synel Test Task

This is a .NET 8 web application for managing employee data, including importing from CSV files and listing employees. It uses PostgreSQL as the database.

---

## ✅ Prerequisites

Before running the project, make sure the following are installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/) (version 13 or higher)

> 📝 Make sure PostgreSQL is running locally and accessible with the provided credentials.

---

## ⚙️ Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/akhadov/synel-test-task.git
cd synel-test-task
```

### 2. Configure the Database Connection

Open `appsettings.json` in the `SynelTask.Web` project and verify or update the PostgreSQL connection string:

```json
{
  "ConnectionStrings": {
    "Database": "Host=localhost;Port=5432;Database=synel-task;Username=postgres;Password=postgres;Include Error Detail=true"
  }
}
```
### 3. Set the Startup Project

Make sure the `SynelTask.Web` project is set as the **Startup Project** in your IDE (such as Visual Studio or JetBrains Rider).

If you are using the command line, make sure to navigate into the `SynelTask.Web` directory before running commands.

---

### 4. Apply EF Core Migrations

Use Entity Framework Core to apply migrations and create the database schema:

```bash
dotnet ef database update
```

### 5. Run the Application

To start the application, run the following command inside the `SynelTask.Web` directory:

```bash
dotnet run

