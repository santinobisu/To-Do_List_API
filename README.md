# Project Idea

The main idea is to offer an API capable of allowing users to save, update and access their own To-Do Tasks via Basic Authentication.

It uses SQLite as the Database Provider.


Things like Email data and Username/Password change are not implemented as this project purpose is to serve as practice.


# Project Folders
**‣ Authentication**: Holds the handler for Basic  Auth.

**‣ Controllers**:    Contains Controllers for the API Endpoints.

**‣ DTOs**:           Request and Response Data-Transfer-Objects for user interaction w/ Controllers.

**‣ Exceptions**:     Custom Exceptions that throw data validation errors.

**‣ Interfaces**:     Interfaces of Repositories and Services for DE and IoC Container implementation.

**‣ Migrations**:     Database Migrations (Made by EF Core).

**‣ Models**:         Entities domain classes.

**‣ Persistence**:    Repositories and DbContext for database interaction.

**‣ Services**:       Entities Services for business logic and data validation.

**‣ Utils**:          Static utility classes like Error handlers and mapping 


# API Endpoints

## POST 
### » api/Users: 
Creates a new User that can be Authenticated by Basic Auth.


JSON: { username: "", password: ""}


### » api/ToDoItems: 
Creates a new Task associated with the user that made the request. Requires Authentication.


JSON: { description: "", dueDate: ""}


## GET 
### » api/Users/{id}:
Gets the user with the specified id (in Guid format).


### » api/ToDoItems:
Gets a list that contains all of the user Tasks, detailed. Requieres Authentication.


#### Optional queries: 

**api/ToDoItems?isCompleted=** -> true or false, only shows Tasks with the specified status.


**api/ToDoItems?dueDate=** -> YYYY-MM-DD, you must specify a date with a valid DateTime format. Shows all the Tasks whose Due Dates are after the specified Date.

You can combine the queries, E.g: api/ToDoItems?isCompleted=true&dueDate=2024-10-05 -> Would return all of the user's Tasks that are marked as completed and whose due date are after 2024-10-05

## DELETE
### » api/Users/{id}:
Deletes the user with the specified id (in Guid format), if it exists.

### » api/ToDoItems/{id}:
Deletes the user's Task with the specified id (in Guid format), if it exists.

## UPDATE
### » api/ToDoItems/{id}:
Updates the user's Task status (from false to true, or vice versa) with the specified id (in Guid format), if it exists.

# Dependencies
#### • Microsoft.EntityFrameworkCore
#### • Microsoft.EntityFrameworkCore.Design
#### • BCrypt.Net-Next
#### • Microsoft.EntityFrameworkCore.Sqlite
