FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Chat/Chat.csproj", "Chat/"]
RUN dotnet restore "Chat/Chat.csproj"
COPY . .
WORKDIR "/src/Chat"
RUN dotnet build "Chat.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Chat.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Chat.dll"]