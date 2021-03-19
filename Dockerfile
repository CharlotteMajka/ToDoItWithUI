
FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
COPY ./src/UI/bin/Debug/net5.0 .
COPY ./src/UI/wwwroot ./wwwroot
ENTRYPOINT ["dotnet", "UI.dll"]