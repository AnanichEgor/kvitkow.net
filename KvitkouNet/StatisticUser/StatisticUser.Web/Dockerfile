FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["StatisticUser.Web/StatisticUser.Web.csproj", "StatisticUser.Web/"]
RUN dotnet restore "StatisticUser.Web/StatisticUser.Web.csproj"
COPY . .
WORKDIR "/src/StatisticUser.Web"
RUN dotnet build "StatisticUser.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StatisticUser.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StatisticUser.Web.dll"]