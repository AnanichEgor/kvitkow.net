FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["UserManagement.Web/UserManagement.Web.csproj", "UserManagement.Web/"]
RUN dotnet restore "UserManagement.Web/UserManagement.Web.csproj"
COPY . .
WORKDIR "/src/UserManagement.Web"
RUN dotnet build "UserManagement.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UserManagement.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UserManagement.Web.dll"]