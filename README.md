# ClassNotes Fullstack CI/CD Project

This project shows a DevOps-Example using:
- React-Frontend (GitHub Pages)
- ASP.NET Core Minimal API Backend (Azure App Service Deployment)
- SQLite Database
- GitHub Actions CI/CD Pipelines


## Create Backend and Frontend
1. Create a new repository in GitHub
2. Clone the repo

### Create Backend
3. Create [ClassNotes.Api](#ClassNotes.Api)
4. open sln in Visual Studio 
5. create Models and Data files
6. change Program.cs
7. Create [sqlite database](#createsql)

<br>
<h3 id="ClassNotes.Api">Creating ClassNotes.Api</h3>


1. dotnet new webapi -n ClassNotes.Api
2. cd ClassNotes.Api

3. dotnet add package Microsoft.EntityFrameworkCore
4. dotnet add package Microsoft.EntityFrameworkCore.Sqlite
5. dotnet add package Microsoft.EntityFrameworkCore.Design

6. dotnet add package Microsoft.EntityFrameworkCore.Tools
7. dotnet add package Swashbuckle.AspNetCore

8. dotnet new sln -n classnotes
9. dotnet sln add "ClassNotes.Api.csproj"
<br><br>

<h3 id="createsql">Creating sqlite database</h3>

type following in package-manager-console
1. add-migration Init
2. update-database

<br>

### Create Frontend
1. npm create vite@latest frontend
2. change files given by teacher
3. npm run dev - to start the frontend

*Tip*: allow the react application in the backend to avoid the CORS-error

