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
  
# Vulnerabilities
## Over-posting
Overposting happens when an attacker or a user submits more data than expected (e.g., modifying fields they shouldn't).  
```cs
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(Movie movie)
{
    _context.Add(movie);  // Directly binding the entire entity (BAD)
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}
```
  
**Defend with:**
  
### ViewModel class
```cs
public class MovieCreateViewModel
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
}
```
  
```cs
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(MovieCreateViewModel model)
{
    if (ModelState.IsValid)
    {
        var movie = new Movie
        {
            Title = model.Title,
            Genre = model.Genre,
            Year = model.Year
        };

        _context.Add(movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(model);
}
```
  
### Bind attribute
```cs
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Title,Genre,Year")] Movie movie)
{
    if (ModelState.IsValid)
    {
        _context.Add(movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(movie);
}
```
  
### From... attribute
[FromForm] - Accepts data from form submissions (e.g., HTML forms).
[FromBody] - Accepts data from the request body (useful for APIs).
[FromQuery] - Accepts data from URL query parameters.
  
```cs
[HttpPost]
public IActionResult Create([FromForm] MovieCreateViewModel model)
{
    if (ModelState.IsValid)
    {
        var movie = new Movie { Title = model.Title, Genre = model.Genre, Year = model.Year };
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(model);
}
```
  
### JsonIgnore attribute
```cs
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    
    [JsonIgnore] // Prevent overposting of sensitive fields
    public bool IsAdminOnly { get; set; }
}
```
  
## Cross-Site Request Forgery (CSRF/XSRF)
CSRF (Cross-Site Request Forgery) is a security vulnerability where an attacker tricks a logged-in user into performing unwanted actions on a trusted website without their consent.  
**Example Attack Scenario:**  
1. A user logs into yourbank.com.
2. The attacker sends a malicious request (e.g., a hidden form submission) to yourbank.com/transfer without user interaction.
3. Since the user's session (cookies) is valid, the request executes with their permissions.
  
**Defend with:**
  
### Anti-Forgery Tokens
```html
// Razor page
<form asp-action="Edit">
    @Html.AntiForgeryToken()

// Or
<form asp-action="Edit" method="post" asp-antiforgery="true">
```
  
```cs
// Controller
[HttpPost]
[ValidateAntiForgeryToken] // Ensures anti-forgery token is required
public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
```
  