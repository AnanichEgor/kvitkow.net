FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AdminPanel.Web/AdminPanel.Web.csproj", "AdminPanel.Web/"]
RUN dotnet restore "AdminPanel.Web/AdminPanel.Web.csproj"
COPY . .
WORKDIR "/src/AdminPanel.Web"
RUN dotnet build "AdminPanel.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AdminPanel.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AdminPanel.Web.dll"]