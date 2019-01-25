FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Dashboard.Web/Dashboard.Web.csproj", "Dashboard.Web/"]
COPY ["Dashboard.Data/Dashboard.Data.csproj", "Dashboard.Data/"]
COPY ["Dashboard.Logic/Dashboard.Logic.csproj", "Dashboard.Logic/"]
RUN dotnet restore "Dashboard.Web/Dashboard.Web.csproj"
COPY . .
WORKDIR "/src/Dashboard.Web"
RUN dotnet build "Dashboard.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Dashboard.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Dashboard.Web.dll"]