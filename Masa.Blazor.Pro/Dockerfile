#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM registry.cn-hangzhou.aliyuncs.com/masa/dotnet_aspnet:8.0.3 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:80
EXPOSE 80
EXPOSE 443

FROM registry.cn-hangzhou.aliyuncs.com/masa/sdk:8.0.203 AS build
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
