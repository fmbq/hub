FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out server/src/server.csproj

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=0 /app/out .
COPY --from=1 /app/wwwroot wwwroot
EXPOSE 80
ENTRYPOINT ["/app/server"]
