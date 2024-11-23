FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /{DOCKER_WORKDIR}
COPY ["src/Api/ZACx.Templates.WebApiProject.Api.csproj", "src/Api/"]
COPY ["src/Business/ZACx.Templates.WebApiProject.Business.csproj", "src/Business/"]
COPY ["src/Core/ZACx.Templates.WebApiProject.Core.csproj", "src/Core/"]
COPY ["src/DataAccess/ZACx.Templates.WebApiProject.DataAccess.csproj", "src/DataAccess/"]
COPY ["src/Entities/ZACx.Templates.WebApiProject.Entities.csproj", "src/Entities/"]
RUN dotnet restore "src/Api/ZACx.Templates.WebApiProject.Api.csproj"
COPY . .
WORKDIR "/{DOCKER_WORKDIR}/src/Api"
RUN dotnet build "ZACx.Templates.WebApiProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZACx.Templates.WebApiProject.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZACx.Templates.WebApiProject.Api.dll"]