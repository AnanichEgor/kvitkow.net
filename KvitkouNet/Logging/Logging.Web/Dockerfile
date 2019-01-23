FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Logging/Logging.Web/Logging.Web.csproj", "Logging/Logging.Web/"]
COPY ["Logging/Logging.Logic/Logging.Logic.csproj", "Logging/Logging.Logic/"]
COPY ["Logging/Logging.Data/Logging.Data.csproj", "Logging/Logging.Data/"]
COPY ["KvitkouNet.Logic.Comon/KvitkouNet.Logic.Common.csproj", "KvitkouNet.Logic.Comon/"]
RUN dotnet restore "Logging/Logging.Web/Logging.Web.csproj"
COPY . .
WORKDIR "/src/Logging/Logging.Web"
RUN dotnet build "Logging.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Logging.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Logging.Web.dll"]