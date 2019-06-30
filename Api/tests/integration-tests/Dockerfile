FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ./api/src/ ./api
RUN dotnet restore ./api/Api.csproj
COPY ./api/tests/integration-tests/ ./test
RUN dotnet add ./test/integration-tests.csproj reference ./api/Api.csproj
RUN dotnet restore ./test/integration-tests.csproj

RUN dotnet test ./test