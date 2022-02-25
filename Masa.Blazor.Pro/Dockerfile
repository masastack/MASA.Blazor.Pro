#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Masa.Blazor.Pro/Masa.Blazor.Pro.csproj", "Masa.Blazor.Pro/"]
RUN dotnet restore "Masa.Blazor.Pro/Masa.Blazor.Pro.csproj"
COPY . .
WORKDIR "/src/Masa.Blazor.Pro"
RUN dotnet build "Masa.Blazor.Pro.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Masa.Blazor.Pro.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Masa.Blazor.Pro.dll"]
