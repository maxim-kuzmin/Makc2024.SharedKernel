#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG APP_PROJECT=Backend.Services.TaskReader.Web.csproj

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG APP_PATH
ARG APP_PROJECT
WORKDIR /src
COPY ["$APP_PATH$APP_PROJECT", "$APP_PATH"]
RUN dotnet restore "$APP_PATH$APP_PROJECT"
COPY . .
WORKDIR "/src/$APP_PATH"
RUN dotnet build "$APP_PROJECT" -c Release -o /app/build

FROM build AS publish
ARG APP_PROJECT
RUN dotnet publish "$APP_PROJECT" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.Services.TaskReader.Web.dll"]