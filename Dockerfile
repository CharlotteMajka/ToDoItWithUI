
FROM mcr.microsoft.com/dotnet/aspnet:5.0 
WORKDIR /src
COPY src/API/bin/Debug/net5.0/ .
ENTRYPOINT ["dotnet", "API.dll"]
