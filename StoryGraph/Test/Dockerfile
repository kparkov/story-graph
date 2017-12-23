FROM microsoft/dotnet:2-sdk
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and run test
COPY . ./
ENTRYPOINT ["dotnet", "test"]