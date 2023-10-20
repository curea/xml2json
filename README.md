To create a single file .net exe:
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true
dotnet publish -r osx-x64 -c Release /p:PublishSingleFile=true