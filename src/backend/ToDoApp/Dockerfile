#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7105
EXPOSE 5186

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ToDoApp/ToDoApp.csproj", "ToDoApp/"]
COPY ["OutputEntities/OutputPort.csproj", "OutputEntities/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Entities/InputPort.csproj", "Entities/"]
COPY ["CoreEntities/CoreEntities.csproj", "CoreEntities/"]
COPY ["Application/Application.csproj", "Application/"]

RUN dotnet restore "ToDoApp/ToDoApp.csproj"

COPY . .

WORKDIR "/src/ToDoApp"
RUN dotnet build "ToDoApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.dll"]