# WebAPi
Thanks for looking into my project. This project was built using Asp.Net Core 6 with Web API, Rest API, as a Monolite.
I divided my project into different layers that communicate via DI in order to gain encapsulation and flexibility
1.Controller- which includes controllers 
2.BL- for business logic
3.DAL-for connecting to the database Entity Framework Core 6 as then ORM with a code-first approach
I have a middleware which is designed to handle user authentication using JWT (JSON Web Tokens). It extracts the token from the `Authorization` header, validates it, and maps its claims (e.g., `userId`, `Role`) to a `User` object, which is then stored in the request context for downstream processing.
In addition, I have a swagger that describes my project structure.
DTO for transferring data to the client using Auto Mapper.
I gave special attention to scaling the site by using async/await.
Error handling is taken care of by logging with NLOG. All errors should be caught using a middleware for that.
Configuration file (appsettings.json) for environment variables. I added a rating middleware to record all site entries.
### How to run the project?
Using Visual Studio 2022 with .NET 6 and SQL Server Management Studio,
Create the database using EF code First:
Open the package manager terminal in Visual Studio: Go to "Tools" "NuGet Package Manager" "Package Manager Terminal".
In the package manager console, select the project (WebApiSite) from the "Default Project" dropdown.
Run the following command to create the database:
1.add-migration [MyDataBaseName]
2.Update-DataBase.
And your DB is ready for use!-
### Thanks for checking out my project hope you enjoyed!



