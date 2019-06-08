# homedev-core2.2-console-app
a default .net core 2.2 console application

**Template project**
This is a project to outline and test how to setup a .net core application with the following features:

1. Microsoft Dependency Injection container
2. Logging with Serilog
3. json configuration file

--==============================================
-- Instructions
--==============================================

- Dependency Injection framework
    dotnet add package Microsoft.Extensions.Dependency Injection
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.FileExtensions
    dotnet add package Microsoft.Extensions.Configuration.Json
    dotnet add package Microsoft.Extensions.Logging 
    dotnet add package Microsoft.Extensions.Logging.Console 
    dotnet add package Serilog
    dotnet add package Serilog.Extensions.Logging //This allows for the AddSerilog method
    dotnet add package Serilog.Sinks.Console 
    dotnet add package Serilog.Sinks.File 
    dotnet add package Serilog.Sinks.RollingFile
    

** Configuration - Tips and Tricks **
The configuration file "appsettings.json" needs to be copied into the bin directory.

The following setting needs to be added to the project

```
  <ItemGroup>
    <None Update="appsettings.json" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>```