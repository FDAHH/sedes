# sedes

# Description
Plan and organize seating for multiple rooms in multiple locations.
Build backend as webservice and later a fontend

# Goal
Sample project for c#, .net, EF, Web API, Blazor (?)
Starting by using ASP.NET Core Web API Template
dotnet new webapi --no-https

dotnet add package Microsoft.EntityFrameworkCore.SQLite -v 5.0.0-*
dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 5.0.0-*
dotnet add package Microsoft.EntityFrameworkCore.Design -v 5.0.0-*
dotnet add package Microsoft.EntityFrameworkCore.Tools -v 5.0.0-*
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 5.0.0-*
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore -v 5.0.0-*  

dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator --version 5.0.0-*  

# Current Issues
Seats are not save as part of Room 

# ToDo Short
Complete Model 
    Company 
    Building
    Room
    Seat

# ToDo Longterm
Add Auth and User managment
Add Visual interface
Add Activity Logging





