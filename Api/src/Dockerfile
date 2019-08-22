FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine AS base
WORKDIR /app
ARG DB_CREDS
ENV DB_CREDS ${DB_CREDS}
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS build
WORKDIR /src
COPY ./Api.csproj ./
RUN dotnet restore ./Api.csproj
COPY . .
RUN dotnet build Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN echo ${DB_CREDS}
ENTRYPOINT ["dotnet", "Api.dll"]