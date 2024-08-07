# CDNFreelancers

CDNFreelancers is a web application for managing a list of freelancers. It includes functionalities to register, view, update, and delete user details. The project is built using ASP.NET Core Razor Pages, Entity Framework Core, and SQL Server.

## For your information, i had completed all 5 questions in the assessment, and completed some of the bonus requirement such as: Client side development skill, Caching Strategy, Pagination, Error Handling, Testing Strategy.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup](#setup)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Database Schema](#database-schema)
- [Project Structure](#project-structure)
- [Testing](#testing)

## Features

- User registration and management
- Real-time form validation for email and phone input fields
- Role-based access control
- Caching for optimized data retrieval
- Error handling and logging

## Technologies Used

- ASP.NET Core Razor Pages
- Entity Framework Core
- Microsoft SQL Server
- Bootstrap 4
- xUnit (for testing)

## Setup

### Prerequisites

- .NET 6 SDK
- SQL Server

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/CDNFreelancers.git
    cd CDNFreelancers
    ```

2. Set up the database:
    - Update the connection string in `appsettings.json` to match your SQL Server configuration:
      ```json
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CDNFreelancersDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
      ```

    - Apply migrations to create the database schema:
      ```sh
      dotnet ef database update
      ```

3. Build and run the project:
    ```sh
    dotnet build
    dotnet run
    ```

### Environment Variables

Ensure the following environment variables are set:

- `ASPNETCORE_ENVIRONMENT` (e.g., Development, Production)

## Usage

- Access the application at `https://localhost:5001`
- Use the navigation links to register, view, edit, and delete users.

## API Endpoints

### User Management

- **GET /api/users**: Retrieve a paginated list of users.
- **GET /api/users/{id}**: Retrieve a specific user by ID.
- **POST /api/users**: Create a new user.
- **PUT /api/users/{id}**: Update an existing user by ID.
- **DELETE /api/users/{id}**: Delete a user by ID.

## Database Schema

The application uses the following database schema for user management:

- **User**:
  - `Id` (int, Primary Key)
  - `Username` (string, Required)
  - `Email` (string, Required, Email Address)
  - `PhoneNumber` (string, Phone)
  - `Skillsets` (string)
  - `Hobby` (string)

## Project Structure

The project follows a standard ASP.NET Core structure:

- **Controllers**: API controllers for managing users.
- **Data**: Entity Framework Core context and database configurations.
- **Models**: Data models for the application.
- **Pages**: Razor Pages for the user interface.
- **wwwroot**: Static files (CSS, JavaScript, etc.).
- **Tests**: Unit tests for the application.

### Key Files

- `Startup.cs`: Configures the request pipeline and services.
- `Program.cs`: Entry point of the application.
- `AppDbContext.cs`: Database context for Entity Framework Core.
- `UsersController.cs`: API controller for user management.
- `ListUsers.cshtml`: Razor Page for listing users.
- `UserForm.cshtml`: Razor Page for user registration and editing.
- `UserForm.cshtml.cs`: Code-behind for `UserForm.cshtml`.

## Testing

The project includes unit tests using xUnit. To run the tests:

```sh
dotnet test
