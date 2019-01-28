FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Logging.Web/Logging.Web.csproj", "Logging.Web/"]
RUN dotnet restore "Logging.Web/Logging.Web.csproj"
COPY . .
WORKDIR "/src/Logging.Web"
RUN dotnet build "Logging.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Logging.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Logging.Web.dll"]