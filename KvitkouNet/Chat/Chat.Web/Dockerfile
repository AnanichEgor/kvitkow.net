FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Chat.Web/Chat.Web.csproj Chat.Web/
COPY Chat.Logic/Chat.Logic.csproj Chat.Logic/
COPY Chat.Data/Chat.Data.csproj Chat.Data/
RUN dotnet restore Chat.Web/Chat.Web.csproj
COPY . .
WORKDIR /src/Chat.Web
RUN dotnet build Chat.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Chat.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chat.Web.dll"]
