FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY TicketManagement.Web/*.csproj ./TicketManagement.Web/
COPY TicketManagement.Data/*.csproj ./TicketManagement.Data/
COPY TicketManagement.Logic/*.csproj ./TicketManagement.Logic/
COPY TicketManagement.Test/*.csproj ./TicketManagement.Test/
RUN dotnet restore
COPY . .
WORKDIR "/src/TicketManagement.Web"
RUN dotnet build "TicketManagement.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TicketManagement.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TicketManagement.Web.dll"]