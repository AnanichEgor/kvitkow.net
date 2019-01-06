FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["UserSettings/UserSettings.csproj", "UserSettings/"]
RUN dotnet restore "UserSettings/UserSettings.csproj"
COPY . .
WORKDIR "/src/UserSettings"
RUN dotnet build "UserSettings.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserSettings.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserSettings.dll"]