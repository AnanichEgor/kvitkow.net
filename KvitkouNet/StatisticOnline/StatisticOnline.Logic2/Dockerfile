FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["StatisticOnline.Logic/StatisticOnline.Logic.csproj", "StatisticOnline.Logic/"]
RUN dotnet restore "StatisticOnline.Logic/StatisticOnline.Logic.csproj"
COPY . .
WORKDIR "/src/StatisticOnline.Logic"
RUN dotnet build "StatisticOnline.Logic.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StatisticOnline.Logic.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StatisticOnline.Logic.dll"]