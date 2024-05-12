# Use the official Microsoft .NET image.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use SDK image to build the application.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AuroqueWebApi/AuroqueWebApi.csproj", "./"]
RUN dotnet restore "AuroqueWebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AuroqueWebApi/AuroqueWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuroqueWebApi/AuroqueWebApi.csproj" -c Release -o /app/publish

# Final stage/image.
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuroqueWebApi.dll"]
