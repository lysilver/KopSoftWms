FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

COPY . .
ENTRYPOINT ["dotnet", "KopSoftWms.dll"]