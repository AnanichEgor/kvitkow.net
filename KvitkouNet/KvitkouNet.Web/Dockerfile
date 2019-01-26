FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 19615
EXPOSE 44330

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
COPY KvitkouNet.Web/KvitkouNet.Web.csproj KvitkouNet.Web/
COPY KvitkouNet.Logic.Comon/KvitkouNet.Logic.Common.csproj KvitkouNet.Logic.Comon/
RUN dotnet restore KvitkouNet.Web/KvitkouNet.Web.csproj
COPY . .
WORKDIR /src/KvitkouNet.Web
RUN dotnet build KvitkouNet.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish KvitkouNet.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KvitkouNet.Web.dll"]
