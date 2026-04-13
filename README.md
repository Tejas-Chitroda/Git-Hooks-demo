# Student API

A .NET Core Web API project for managing student details with in-memory storage.

## Project Structure

```
StudentApi/
├── Controllers/
│   └── StudentsController.cs    # API endpoints
├── Services/
│   ├── IStudentService.cs        # Service interface
│   └── StudentService.cs         # Business logic layer
├── Repositories/
│   ├── IStudentRepository.cs     # Repository interface
│   └── StudentRepository.cs      # Data access layer (in-memory)
├── Models/
│   └── Student.cs                # Student model
├── Program.cs                    # Application entry point
└── StudentApi.csproj             # Project file
```

## Features

- Clean architecture with separation of concerns
- In-memory data storage (no database required)
- Full CRUD operations for student management
- Swagger UI for API documentation and testing
- Pre-seeded with sample student data

## Prerequisites

- .NET 8.0 SDK or later

## Running the Application

1. Navigate to the project directory:
   ```bash
   cd c:\Git-Hooks-Demo
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Open your browser and navigate to:
   - Swagger UI: `https://localhost:5001/swagger` or `http://localhost:5000/swagger`

## API Endpoints

### Get All Students
- **GET** `/api/students`
- Returns a list of all students

### Get Student by ID
- **GET** `/api/students/{id}`
- Returns a specific student by ID

### Add New Student
- **POST** `/api/students`
- Request body:
  ```json
  {
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@example.com",
    "dateOfBirth": "2000-01-15T00:00:00",
    "phoneNumber": "123-456-7890",
    "address": "123 Main St, City, State"
  }
  ```

### Update Student
- **PUT** `/api/students/{id}`
- Request body: Same as POST

### Delete Student
- **DELETE** `/api/students/{id}`
- Removes a student from the system

## Sample Data

The application comes pre-seeded with 3 sample students for testing purposes.

## Testing with Swagger

1. Run the application
2. Navigate to the Swagger UI
3. Expand any endpoint
4. Click "Try it out"
5. Fill in the required parameters
6. Click "Execute"

## Architecture Layers

1. **Controller Layer**: Handles HTTP requests and responses
2. **Service Layer**: Contains business logic and validation
3. **Repository Layer**: Manages data access and in-memory storage
4. **Model Layer**: Defines data structures

## Notes

- Data is stored in-memory and will be lost when the application stops
- The application uses a singleton pattern for the repository to maintain data across requests during runtime
