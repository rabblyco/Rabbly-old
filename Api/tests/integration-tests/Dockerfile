FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ./Api/src/ ./Api
RUN dotnet restore ./Api/Api.csproj
COPY ./Api/tests/integration-tests/ ./test
RUN dotnet add ./test/integration-tests.csproj reference ./Api/Api.csproj
RUN dotnet restore ./test/integration-tests.csproj

RUN dotnet test ./test