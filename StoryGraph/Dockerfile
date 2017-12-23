FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./StoryGraph.sln ./
COPY ./Api/Api.csproj ./Api/
COPY ./Model/Model.csproj ./Model/
COPY ./Test/Test.csproj ./Test/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/Api/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Api.dll"]