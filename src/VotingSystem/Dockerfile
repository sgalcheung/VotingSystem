FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/VotingSystem/VotingSystem.csproj", "src/VotingSystem/"]
RUN dotnet restore "src/VotingSystem/VotingSystem.csproj"
COPY . .
WORKDIR "/src/src/VotingSystem"
RUN dotnet build "VotingSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VotingSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VotingSystem.dll"]
