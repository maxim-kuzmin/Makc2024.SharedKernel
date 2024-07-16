#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG APP_PATH
ARG APP_PORT_HTTP
ARG APP_PORT_HTTPS
ARG APP_PROJECT_NAME
ARG BUILD_CONFIGURATION

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ARG APP_PATH
USER app
WORKDIR $APP_PATH
EXPOSE $APP_PORT_HTTP
EXPOSE $APP_PORT_HTTPS

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG APP_PATH
ARG APP_PROJECT_NAME
ARG BUILD_CONFIGURATION
WORKDIR /src
COPY ["$APP_PROJECT_NAME.csproj", "."]
RUN dotnet restore "./$APP_PROJECT_NAME.csproj"
COPY . .
RUN dotnet build "./$APP_PROJECT_NAME.csproj" -c $BUILD_CONFIGURATION -o $APP_PATH/build

FROM build AS publish
ARG APP_PATH
ARG APP_PROJECT_NAME
ARG BUILD_CONFIGURATION
RUN dotnet publish "./$APP_PROJECT_NAME.csproj" -c $BUILD_CONFIGURATION -o $APP_PATH/publish /p:UseAppHost=false

FROM base AS final
ARG APP_PATH
ARG APP_PROJECT_NAME
WORKDIR $APP_PATH
COPY --from=publish $APP_PATH/publish .
ENTRYPOINT ["dotnet", "$APP_PROJECT_NAME.dll"]