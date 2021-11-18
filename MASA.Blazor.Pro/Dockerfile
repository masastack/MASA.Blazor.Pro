#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MASA.Blazor.Pro/MASA.Blazor.Pro.csproj", "MASA.Blazor.Pro/"]
RUN dotnet restore "MASA.Blazor.Pro/MASA.Blazor.Pro.csproj"
COPY . .
WORKDIR "/src/MASA.Blazor.Pro"
RUN dotnet build "MASA.Blazor.Pro.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MASA.Blazor.Pro.csproj" -c Release -o /app/publish && ls /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MASA.Blazor.Pro.dll"]
