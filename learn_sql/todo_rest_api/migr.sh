#!/bin/bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 5.0.2
dotnet add package EFCore.NamingConventions --version 5.0.2
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Npgsql --version 5.0.4

dotnet ef migrations add InitialSchema
dotnet ef database update
