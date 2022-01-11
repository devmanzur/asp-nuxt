FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleCart.Web/SimpleCart.Web.csproj", "SimpleCart.Web/"]
COPY ["SimpleCart.Infrastructure/SimpleCart.Infrastructure.csproj", "SimpleCart.Infrastructure/"]
COPY ["SimpleCart.Core/SimpleCart.Core.csproj", "SimpleCart.Core/"]
RUN dotnet restore "SimpleCart.Web/SimpleCart.Web.csproj"
COPY . .
WORKDIR "/src/SimpleCart.Web"
RUN dotnet build "SimpleCart.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleCart.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleCart.Web.dll"]
