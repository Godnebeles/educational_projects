#!/bin/bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 5.0.2
dotnet add package EFCore.NamingConventions --version 5.0.2
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialSchema
dotnet ef database update

#delete migrations
dotnet ef database update 0
dotnet ef migrations remove
