dotnet publish -c Release src\OpenRpg.Demos.Web.sln
Remove-Item -Recurse -Force 'docs'
md -path 'docs'
Copy-Item -Path "src\OpenRpg.Demos.Web\bin\Release\netstandard2.1\publish\wwwroot\*" -Destination "docs" -Recurse
((Get-Content -path "docs\index.html" -Raw) -replace '<base href="/" />', '<base href="/OpenRpg.Demos.Web/" />') | Set-Content -Path "docs\index.html"