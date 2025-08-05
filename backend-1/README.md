# Project Title: Task Manager API

## Description
This project is a Task Manager API built using ASP.NET Core and Entity Framework Core. It provides a RESTful interface for managing tasks, allowing users to create, read, update, and delete task items.

## Technologies Used
- ASP.NET Core 9.0
- Entity Framework Core
- PostgreSQL
- Docker

## Project Structure
- **Controllers**: Contains the `TasksController` class for handling HTTP requests related to task items.
- **Data**: Contains the `AppDbContext` class for configuring the database context.
- **Migrations**: Contains migration files for database schema changes.
- **Models**: Contains the `TaskItem` class representing a task entity.
- **Repositories**: Intended for data access logic (currently empty).
- **Services**: Intended for business logic (currently empty).

## Setup Instructions
1. **Clone the repository**:
   ```
   git clone <repository-url>
   cd backend
   ```

2. **Configure the database**:
   Ensure you have PostgreSQL installed and running. Update the connection string in `appsettings.json` if necessary.

3. **Build and run the application using Docker**:
   ```
   docker-compose up --build
   ```

4. **Access the API**:
   The API will be available at `http://localhost:5280`.

## API Endpoints
- **GET /weatherforecast**: Retrieves weather forecast data.
- **Tasks**: CRUD operations for task items (to be defined in `TasksController`).

## License
This project is licensed under the MIT License.