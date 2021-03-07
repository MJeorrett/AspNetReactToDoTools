# Asp.Net Core React ToDo Tools
Tools to make following following the patterns in AspNetReactToDo dead simple.

## Scaffolder
The scaffolder currently:
- Creates CRUD commands and queries.
- Creates a CRUD controller.

### Running it
This project is in the very early stages, but if you want to try it out:
- Clone this repo and [AspNetReactToDo](https://github.com/MJeorrett/AspNetReactToDo) into the same directory.
- Fix the project reference to `Anrtd.Application` (this project compiles against AspNetReactToDo).
- Add a new entity to the AspNetReactToDo project as follows:
	- Create a new Entity class in the [Domain](https://github.com/MJeorrett/AspNetReactToDo/tree/main/AnrtdApi/Anrtd.Domain/Entities) project.
	- Add the new entity to [ApplicationDbContext](https://github.com/MJeorrett/AspNetReactToDo/blob/main/AnrtdApi/Anrtd.Infrastructure/Persistence/ApplicationDbContext.cs) in the Infrastructure project.
	- Add the new entity to [IApplicationDbContext](https://github.com/MJeorrett/AspNetReactToDo/blob/main/AnrtdApi/Anrtd.Application/Common/Interfaces/IApplicationDbContext.cs) in the Application project.
	- Create a migration for the new entity.
- Update the two consts in the top of `Program::Main`:
  - `entityName` - must exactly match the name of the new entity you created.
  - `anrtdRepoRoot` - absolute path the root of the AspNetReactToDo repo.
- Ensure `AnrtdScaffolder` is set as the startup project.
- Hit `F5` in Visual Studio.

With a bit of luck (and perhaps a few trials and errors) the project should generate buildable code for the specified entity in the AspNetReactToDo repo.
