FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["UserSettings.Web/UserSettings.Web.csproj", "UserSettings.Web/"]
RUN dotnet restore "UserSettings.Web/UserSettings.Web.csproj"
COPY . .
WORKDIR "/src/UserSettings.Web"
RUN dotnet build "UserSettings.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserSettings.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserSettings.Web.dll"]