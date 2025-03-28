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
   - The relationship is configured in the `AppDbContext` class using `ModelBuilder`.

4. **Design Patterns**:
   - **Repository Pattern**: This is used for data access, allowing us to isolate the logic of interacting with the database.
   - **Unit of Work Pattern**: This pattern is used to manage transactions, ensuring that changes to multiple entities are committed in a single transaction.

5. **JSON Serialization**:
   - We applied the `JsonIgnore` attribute to avoid cyclical references between `Activity` and `Trip` when serializing the objects. If you want to preserve relationships in serialization, you can enable `ReferenceHandler.Preserve`.

## How to Run the Code

### Prerequisites
- .NET 6 or higher
- SQL Server (LocalDB or a full SQL Server instance)

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/travel-experience-service.git
   cd travel-experience-service
