# AutoGlassAPI
Technical Test

This test contains two projects:
WebAPI -> Content all methods to get, insert, update and delete Products and Suppliers
To do this was used next libraries:
    Include="Microsoft.EntityFrameworkCore" Version="6.0.6"
    Include="Microsoft.EntityFrameworkCore.InMemory" Version="6.0.6"
    Include="Swashbuckle.AspNetCore" Version="6.2.3"

This proyect use EF in Memory as data base but is possible change the conection to some database engine using FluentAPI, also was implemented API Rest DDD (Domain Driven Design).
and EntityFramework ORM.

Test -> Content the structure about a class library to make unit test, but it isn't finished yet, also the proyect use some extensions to do the unit test like: 
    Include="Microsoft.NET.Test.Sdk" Version="17.4.0-preview-20220707-01" 
    Include="xunit" Version="2.4.2"
    Include="xunit.runner.visualstudio" Version="2.4.5"
    


