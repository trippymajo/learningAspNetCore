# MVC pattern
Model - Describes a model for data. Consists of the Class and members with `{get; set;}`, which used to describe data in DB.  
View - Output to user. `*.cshtml` items. Some weird mix of html and cs.  
Controller - A bridge between Model and View, which make some manipulations with data and finally shows it to user via View.  
  
As soon as Model created, can automatically generate methods around it which allow easy operations related with DB, also it will  
create the table as represented in model. For this do:  
1. Create Model
2. Controllers -> New Scaffolded Item... -> MVC -> MVC Controller with views, using Entity Framework (for example).  
Choose Model class, `+` for DB context & DB provider.
3. DB created using `Add-Migration InitialCreate` in NuGet Package Manager -> Package Manager Console.  
Here Migration files generated.
4. `Update-Database` - creates database.
  
Application is build with dependency injections

## Dependency injection (DI)
Dependency Injection (DI) is a built-in feature of ASP.NET Core that helps manage dependencies in a clean and testable way.  
Instead of creating objects manually, ASP.NET Core injects them automatically where needed.  
In C++ we do it all manually via Design patterns like fabric, And passing params in constructors.  
| Lifetime   | Description                          |
|------------|--------------------------------------|
| Singleton  | One instance per application.       |
| Scoped     | One instance per HTTP request.      |
| Transient  | New instance every time it’s requested. |
  
