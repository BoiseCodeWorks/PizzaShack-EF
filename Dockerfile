FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Source/PizzaShack.Web/PizzaShack.Web.csproj", "Source/PizzaShack.Web/"]
COPY ["Source/PizzaShack.Business/PizzaShack.Business.csproj", "Source/PizzaShack.Business/"]
COPY ["Source/PizzaShack.Data/PizzaShack.Data.csproj", "Source/PizzaShack.Data/"]
COPY ["Source/PizzaShack.Entities/PizzaShack.Entities.csproj", "Source/PizzaShack.Entities/"]
RUN dotnet restore "Source/PizzaShack.Web/PizzaShack.Web.csproj"
COPY . .
WORKDIR "/src/Source/PizzaShack.Web"
RUN dotnet build "PizzaShack.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PizzaShack.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet PizzaShack.Web.dll