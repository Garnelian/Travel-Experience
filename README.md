# Travel Experience Service

## Overview
This project is a service for managing travel experiences, allowing the creation of trips, including their activities, and calculating the total cost. It uses **Entity Framework Core** with **Code First** approach and supports relationships between trips and activities. The project also implements the **Unit of Work** and **Repository** patterns to ensure maintainable and testable code.

## Database Choice and Rationale

**Database: SQL Server (Code First approach with Entity Framework Core)**

We chose **SQL Server** as the database for this project because:
- **Scalability and Reliability**: SQL Server is a robust relational database system that is well-suited for handling structured data and complex relationships, like those between trips and activities.
- **Familiarity and Integration**: SQL Server integrates seamlessly with Entity Framework Core, which simplifies data access and management.
- **Code First**: Entity Framework Core's **Code First** approach allows us to define the database schema directly in code, making it easier to manage changes to the database structure over time.

## Key Design Decisions

1. **Domain Models**: 
   - The core models in this system are `Trip` and `Activity`. Each `Trip` can have multiple `Activities`, and each `Activity` is associated with a single `Trip` (one-to-many relationship).
   - The **Trip** model contains properties like `Title`, `StartDate`, `EndDate`, and `TotalCost`.
   - The **Activity** model contains properties like `DestinationId`, `Duration`, and `Cost`. It has a foreign key to the `Trip` model.

2. **Validation**: 
   - We have used **Data Annotations** to validate the input data on the models. For example:
     - The `StartDate` and `EndDate` properties on the `Trip` model are validated to ensure they are not null.
     - The `Duration` property on `Activity` is validated to ensure it is a positive integer.
     - The `Cost` property on both `Trip` and `Activity` is validated to ensure it's a positive number.

3. **Relationships**:
   - We established a **one-to-many relationship** between `Trip` and `Activity` using a foreign key (`TripId` in `Activity`).
   - The relationship is configured in the `ApplicationDbContext` class using `ModelBuilder`.

4. **Design Patterns**:
   - **Repository Pattern**: This is used for data access, allowing us to isolate the logic of interacting with the database.
   - **Unit of Work Pattern**: This pattern is used to manage transactions, ensuring that changes to multiple entities are committed in a single transaction.
   - The patterns are implemented to ensure separation of concerns and better maintainability.
   
5. - **Serilog** is used for logging events, providing detailed logs in both the console and a file for easier debugging and monitoring.

## **How to Run the Code**

### **Clone the repository:**
   ```bash
   git clone https://github.com/Garnelian/Travel-Experience.git
   cd Travel-Experience
   ```

### **Database Configuration (SQL Server)**

Ensure that **SQL Server** is running (either in a Docker container or a local instance). Then, perform the necessary migrations using Entity Framework Core:

```bash
dotnet ef database update
```

### **Run the API**

Once all the services are configured, you can run the API:

```bash
dotnet run
```

The API will be available at `http://localhost:5221`.

### **Tests**

Unit and integration tests have been implemented for each of the API services. You can run them using the following command:

```bash
cd TravelExperienceTest
dotnet test --list-tests
```

### **Logs**

The project uses **Serilog** for event logging. Logs are stored both in the console and in a text file (`Logs/app.log`).

## **Technologies Used**

- **.NET 8**: Development framework.
- **SQL Server**: Relational database.
- **Entity Framework Core**: ORM to interact with SQL Server.

## **Assumptions Made**

- The application assumes that **SQL Server** is properly set up and accessible.
- The API endpoints expect a correct JSON format for creating trips and activities.
- Database migrations will be handled manually by running `dotnet ef database update`.

## **Prerequisites**
- .NET 8 or higher
- SQL Server (LocalDB or a full SQL Server instance)
