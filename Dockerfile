
FROM mcr.microsoft.com/dotnet/aspnet:5.0 
WORKDIR /src
COPY ["src/API/API.csproj", "src/API/"]
COPY . .
ENTRYPOINT ["dotnet", "API.dll"]
