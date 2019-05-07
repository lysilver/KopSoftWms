FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["KopSoftWms/KopSoftWms.csproj", "KopSoftWms/"]
COPY ["Orm/Orm.csproj", "Orm/"]
COPY ["YL.Utils/YL.Utils.csproj", "YL.Utils/"]
COPY ["NetCore/YL.NetCore.csproj", "NetCore/"]
COPY ["IServices/IServices.csproj", "IServices/"]
COPY ["Dto/Dto.csproj", "Dto/"]
COPY ["Entity/Entity.csproj", "Entity/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["IRepository/IRepository.csproj", "IRepository/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["NetCoreApp/YL.NetCoreApp.csproj", "NetCoreApp/"]
RUN dotnet restore "KopSoftWms/KopSoftWms.csproj"
COPY . .
WORKDIR "/src/KopSoftWms"
RUN dotnet build "KopSoftWms.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KopSoftWms.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KopSoftWms.dll"]