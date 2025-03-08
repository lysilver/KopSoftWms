FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS http://+5000
COPY . .
ENTRYPOINT ["dotnet", "KopSoftWms.dll"]