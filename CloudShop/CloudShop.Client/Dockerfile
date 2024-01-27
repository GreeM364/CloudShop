#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CloudShop.Client/CloudShop.Client.csproj", "CloudShop.Client/"]
RUN dotnet restore "CloudShop.Client/CloudShop.Client.csproj"
COPY . .
WORKDIR "/src/CloudShop.Client"
RUN dotnet build "CloudShop.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudShop.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudShop.Client.dll"]