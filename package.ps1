dotnet publish -c Release src\OpenRpg.Demos.Web.sln
Copy-Item -Path "src\OpenRpg.Demos.Web\bin\Release\netstandard2.1\publish\wwwroot\*" -Destination "dist" -Recurse