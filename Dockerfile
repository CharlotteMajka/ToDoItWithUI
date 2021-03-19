
FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
COPY ./src/API/bin/Debug/net5.0 .
COPY ./src/API/wwwroot ./wwwroot
ENTRYPOINT ["dotnet", "UI.dll"]