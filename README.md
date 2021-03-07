# Asp.Net Core React ToDo Tools
Tools to make following following the patterns in AspNetReactToDo dead simple.

## Scaffolder
The scaffolder currently:
- Creates crud commands and queries given an entity type name.

### Running it
This project is in the very early stages, but if you want to try it out:
- Clone this repo and [AspNetReactToDo](https://github.com/MJeorrett/AspNetReactToDo) into the same directory.
- Fix the project reference to `Anrtd.Application` (this project compiles against AspNetReactToDo).
- Add a new entity to the ApplicationDbContext in AspNetReactToDo.
- Update the two consts in the top of Program::Main:
- `entityName` - should match the name of the new entity you created.
- `apiApplicationProjectRoot` - absolute path the directory containing the Api project in the AspNetReactToDo repo.
- Hit `F5` in Visual Studio.

With a bit of luck (and perhaps a couple of trials and errors) the project should generate runnable code in the AspNetReactToDo repo.
