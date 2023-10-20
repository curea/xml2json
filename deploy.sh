dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true
dotnet publish -r osx-x64 -c Release /p:PublishSingleFile=true
dotnet publish -r osx-arm64 -c Release -p:PublishSingleFile=true