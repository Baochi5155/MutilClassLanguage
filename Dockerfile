# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["AudioGuide.API/AudioGuide.API.csproj", "AudioGuide.API/"]
COPY ["AudioGuide.BLL/AudioGuide.BLL.csproj", "AudioGuide.BLL/"]
COPY ["AudioGuide.DAL/AudioGuide.DAL.csproj", "AudioGuide.DAL/"]
RUN dotnet restore "AudioGuide.API/AudioGuide.API.csproj"

COPY . .
WORKDIR "/src/AudioGuide.API"
RUN dotnet publish "AudioGuide.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "AudioGuide.API.dll"]
