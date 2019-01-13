FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["StatisticOnline.Data/StatisticOnline.Data.csproj", "StatisticOnline.Data/"]
RUN dotnet restore "StatisticOnline.Data/StatisticOnline.Data.csproj"
COPY . .
WORKDIR "/src/StatisticOnline.Data"
RUN dotnet build "StatisticOnline.Data.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StatisticOnline.Data.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StatisticOnline.Data.dll"]