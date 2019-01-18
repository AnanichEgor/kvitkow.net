FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Security.Web/Security.Web.csproj", "Security.Web/"]
RUN dotnet restore "Security.Web/Security.Web.csproj"
COPY . .
WORKDIR "/src/Security.Web"
RUN dotnet build "Security.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Security.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Security.Web.dll"]