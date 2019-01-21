FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Notification.Web/Notification.Web.csproj Notification.Web/
COPY Notification.Logic/Notification.Logic.csproj Notification.Logic/
COPY Notification.Data/Notification.Data.csproj Notification.Data/
RUN dotnet restore Notification.Web/Notification.Web.csproj
COPY . .
WORKDIR /src/Notification.Web
RUN dotnet build Notification.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Notification.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Notification.Web.dll"]
