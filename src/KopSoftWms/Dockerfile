FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

COPY . .
ENTRYPOINT ["dotnet", "KopSoftWms.dll"]