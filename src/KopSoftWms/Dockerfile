#FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 5000

COPY . .
ENTRYPOINT ["dotnet", "KopSoftWms.dll"]